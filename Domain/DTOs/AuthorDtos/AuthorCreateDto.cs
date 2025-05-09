using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.AuthorDtos
{
    public class AuthorCreateDto
    {
        public string AuthorName { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public DateOnly? BirthDate { get; set; }
        public DateOnly? DeathDate { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
