
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.AuthDtos
{
    public class LoginDto
    {
        [EmailAddress]
        public string Email{ get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
