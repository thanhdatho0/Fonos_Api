
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.AuthDtos
{
    public class UpdateAccountDto
    {
        [EmailAddress] 
        public string Email { get; set; } = null!;
        public string OldPassword { get; set; } = null!;
        public string NewPassword { get; set;} = null!;
        public string ConfirmPassword {  get; set; } = null! ;
    }
}
