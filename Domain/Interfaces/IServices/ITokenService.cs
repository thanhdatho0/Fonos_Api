using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.AuthDtos;
using Domain.Entities;

namespace Domain.Interfaces.IServices
{
    public interface ITokenService
    {
        TokenDto CreateToken(AppUser user, IList<string> roles);
        TokenDto? RefreshToken(AppUser user, string clientRefreshToken, IList<string> roles);
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    }
}
