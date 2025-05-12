using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DTOs.RatingDtos
{
    public class RatingCreateDto
    {
        public string AppUserId { get; set; } = null!;
        public Guid BookId { get; set; }
        public double RatingValue { get; set; }
        public string? ReviewText { get; set; }
        public bool IsVisible { get; set; }
    }
}
