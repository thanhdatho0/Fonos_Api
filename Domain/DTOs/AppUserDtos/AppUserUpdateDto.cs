using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.AppUserDtos
{
    public class AppUserUpdateDto
    {
        public string FullName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string AvatarUrl { get; set; } = null!;
    }
}
