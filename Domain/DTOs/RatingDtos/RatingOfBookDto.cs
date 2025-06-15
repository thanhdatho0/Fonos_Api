using Domain.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.RatingDtos
{
    public class RatingOfBookDto
    {
        public double RatingValue { get; set; }
        public string? ReviewText { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsVisible { get; set; }
        public AppUserDto AppUser { get; set; } = null!;
    }
}
