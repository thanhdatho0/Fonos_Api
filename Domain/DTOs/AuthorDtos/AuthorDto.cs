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
        public string AuthorName { get; set; } = null!;
        public string Biography { get; set; } = null!;
        public DateOnly? BirthDate { get; set; }
        public DateOnly? DeathDate { get; set; }
        public string Nationality { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
