using Domain.DTOs.AuthDtos;
using Domain.Entities;
using Domain.Interfaces.IServices;
using Domain.Interfaces;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DataAccess.EFCore.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.SqlServer.Server;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authentication.Google;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(
        IConfiguration config,
        IUnitOfWork unitOfWork,
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        ITokenService tokenService,
        IEmailSenderService emailSender) : ControllerBase
    {
        private readonly IConfiguration _config = config;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly SignInManager<AppUser> _signInManager = signInManager;
        private readonly ITokenService _tokenService = tokenService;
        private readonly IEmailSenderService _emailSender = emailSender;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                if (user == null)
                {
                    return Unauthorized("Tên đăng nhập hoặc mật khẩu không trùng khớp 1.");
                }
                var res = await _userManager.CheckPasswordAsync(user, loginDto.Password);

                if (!res)
                {
                    return Unauthorized("Tên đăng nhập hoặc mật khẩu không trùng khớp 2.");
                }

                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    // Tạo Token xác thực Email
                    var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    if (emailToken == null) return NotFound("Không thể tạo token xác thực email");
                    var endcodeToken = WebUtility.UrlEncode(emailToken); //Mã hóa

                    //Gửi link xác nhận trỏ tới API endpoint
                    var confirmUrl = $"{_config["App:ApiBaseUrl"]}/api/Auth/confirm-email?userId={user.Id}&token={endcodeToken}";
                    try
                    {
                        await _emailSender.SendEmailAsync(loginDto.Email, "Xác nhận email", $"<p>Nhấn vào <a href='{confirmUrl}'>đây</a> để xác nhận email.</p>");
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(400, ex.Message);
                    }

                    return Unauthorized("Vui lòng xác nhận email.");
                }
                var roles = await _userManager.GetRolesAsync(user);
                var tokens = _tokenService.CreateToken(user, roles);
                if (tokens == null) return StatusCode(400, "Không thể sinh token");
                
                user.LastLoginDate = DateTime.UtcNow;
                await _userManager.UpdateAsync(user);
                return Ok(new AuthDto
                {
                    Id = user.Id!,
                    Tokens = tokens
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginRequest googleLoginDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Verify Google ID token
                var payload = await GoogleJsonWebSignature.ValidateAsync(googleLoginDto.IdToken, new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = new[] { _config["Authentication:Google:ClientId"] }
                });

                // Find or create user
                var user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    user = new AppUser
                    {
                        UserName = payload.Email,
                        Email = payload.Email,
                        FullName = payload.Name,
                        AvatarUrl = payload.Picture,
                        RegistrationDate = DateTime.UtcNow,
                        IsActive = true,
                        IsVerified = true,
                        EmailConfirmed = true
                    };

                    var createResult = await _userManager.CreateAsync(user);
                    if (!createResult.Succeeded)
                    {
                        return StatusCode(400, createResult.Errors);
                    }
                    await _userManager.AddToRoleAsync(user, "User");
                }

                // Create claims for authentication
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, payload.Subject),
                    new Claim(ClaimTypes.Name, payload.Name),
                    new Claim(ClaimTypes.Email, payload.Email),
                    new Claim("picture", payload.Picture)
                };

                var claimsIdentity = new ClaimsIdentity(claims, GoogleDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(
                    GoogleDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                // Generate tokens
                var roles = await _userManager.GetRolesAsync(user);
                var tokens = _tokenService.CreateToken(user, roles);
                if (tokens == null)
                {
                    return StatusCode(400, "Không thể sinh token");
                }

                user.LastLoginDate = DateTime.UtcNow;
                await _userManager.UpdateAsync(user);

                return Ok(new AuthDto
                {
                    Id = user.Id!,
                    Tokens = tokens
                });
            }
            catch (InvalidJwtException)
            {
                return Unauthorized("Token Google không hợp lệ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }   

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto) //Tham số nhận vào mã số sv
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState); // Kiểm tra tình trạng server

                if (!registerDto.Password.Equals(registerDto.ConfirmPassword))
                    return StatusCode(400, "Mật khẩu không trùng khớp");
                // Tạo User
                var user = new AppUser
                {
                    FullName = registerDto.Email,
                    DateOfBirth = registerDto.DateOfBirth,
                    Gender = registerDto.Gender,
                    AvatarUrl = registerDto.AvatarUrl,
                    RegistrationDate = DateTime.UtcNow,
                    IsActive = false,
                    IsVerified = false,
                    UserName = registerDto.Email,
                    Email = registerDto.Email,
                };
                var createUser = await _userManager.CreateAsync(user, registerDto.Password);
                if (!createUser.Succeeded)
                    return StatusCode(400, createUser.Errors);
                await _userManager.AddToRoleAsync(user, "User");

                // Tạo Token xác thực Email
                var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                if (emailToken == null) return NotFound("Không thể tạo token xác thực email");
                var endcodeToken = WebUtility.UrlEncode(emailToken); //Mã hóa

                //Gửi link xác nhận trỏ tới API endpoint
                var confirmUrl = $"{_config["App:ApiBaseUrl"]}/api/Auth/confirm-email?userId={user.Id}&token={endcodeToken}";

                await _emailSender.SendEmailAsync(user.Email, "Xác nhận email", $"<p>Nhấn vào <a href='{confirmUrl}'>đây</a> để xác nhận email.</p>");

                return Ok("Đăng ký thành công, vui lòng xác nhận email.");
            }
            catch (Exception e)
            {
                var errorResponse = new
                {
                    Message = "Đã có sự cố xảy ra",
                    ErrorMessage = e.Message
                };
                return StatusCode(500, errorResponse);
            }
        }
        
        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (userId == null || token == null)
                    return StatusCode(400, "email hoặc token không hợp lệ");

                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    return StatusCode(400, "Người dùng không tồn tại");
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    user.IsVerified = true;
                    user.IsActive = true;
                    await _userManager.UpdateAsync(user);
                    return Ok("Xác thực Email thành công");
                }
                else
                    return StatusCode(400, "Xác thực Email thất bại");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Đã có lỗi xảy ra trong quá trình xác thực Email {ex.Message}");
            }
        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] UpdateAccountDto updateAccountDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _userManager.FindByEmailAsync(updateAccountDto.Email);
                if (user == null)
                    return StatusCode(400, "Tên đăng nhập hoặc mật khẩu không trùng khớp.");

                var checkPass = await _signInManager.CheckPasswordSignInAsync(user, updateAccountDto.OldPassword, false);
                if (!checkPass.Succeeded)
                    return StatusCode(400, "Tên đăng nhập hoặc mật khẩu không trùng khớp.");

                if (updateAccountDto.NewPassword != updateAccountDto.ConfirmPassword)
                    return StatusCode(400, "Mật khẩu xác thực không trùng khớp");

                var updatedAccount = await _userManager.ChangePasswordAsync(user, updateAccountDto.OldPassword, updateAccountDto.NewPassword);
                if (updatedAccount.Succeeded)
                    return Ok("Đổi mật khẩu thành công");
                else
                    return StatusCode(400, updatedAccount.Errors);
            }
            catch (Exception e)
            {
                var errorResponse = new
                {
                    Message = "Có sự cố xảy ra.",
                    ErrorMessage = e.Message
                };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshRequestDto request)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken); // Giải mã để lấy thông tin user
            if (principal == null)
                return Unauthorized("Invalid access token");

            var userEmail = principal.FindFirstValue(ClaimTypes.Email); // hoặc lấy từ GivenName
            if (userEmail == null) return StatusCode(400, "Người dùng không tồn tại");
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
                return Unauthorized("User not found");

            var roles = await _userManager.GetRolesAsync(user);
            var newTokens = _tokenService.RefreshToken(user, request.RefreshToken, roles);
            if (newTokens == null)
                return Unauthorized("Invalid refresh token");

            await _userManager.UpdateAsync(user); // Lưu refresh token mới

            return Ok(newTokens);
        }
    }
}
