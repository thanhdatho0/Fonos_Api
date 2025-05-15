using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.BookDtos
{
    public class BookCreateDto
    {
        public string Title { get; set; } = null!;
        public string? ISBN { get; set; }
        public Guid? PublisherId { get; set; }
        public int PublicationYear { get; set; }
        public string? Description { get; set; }
        public string CoverImageUrl { get; set; } = null!;
        public string Language { get; set; } = null!;
        public double Price { get; set; }
    }
}
