using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.AuthorDtos
{
    public class AuthorCreateDto
    {
        public string AuthorName { get; set; } = null!;
        public string Biography { get; set; } = null!;
        public DateOnly? BirthDate { get; set; }
        public DateOnly? DeathDate { get; set; }
        public string Nationality { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
