using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.AuthorDtos
{
    public class AuthorDto
    {
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public DateOnly? BirthDate { get; set; }
        public DateOnly? DeathDate { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
