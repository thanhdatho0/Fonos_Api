using DataAcces.EFCore.Mappers;
using Domain.DTOs.AppUserDtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController(IUnitOfWork unitOfWork, UserManager<AppUser> userManager) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly UserManager<AppUser> _userManager = userManager;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _userManager.FindByIdAsync(id);
                return user == null ? NotFound() : Ok(user.ToAppUserDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, AppUserUpdateDto appUserUpdateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _userManager.FindByIdAsync(id);
                if (user == null) return NotFound("Không tìm thấy User");
                user.ToAppUserFromUpdateDto(appUserUpdateDto);
                await _userManager.UpdateAsync(user);
                return Ok(user.ToAppUserDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
