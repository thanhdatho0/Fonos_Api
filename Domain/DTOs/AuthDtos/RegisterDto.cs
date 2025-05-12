
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.AuthDtos
{
    public class RegisterDto
    {
        public string FullName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string AvatarUrl { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
    }
}
