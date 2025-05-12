using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.BookDtos
{
    public class BookDto
    {
        public Guid BookId { get; set; }
        public string Title { get; set; } = null!;
        public int PublicationYear { get; set; }
        public string? Description { get; set; }
        public string CoverImageUrl { get; set; } = null!;
        public string Language { get; set; } = null!;
        public double Price { get; set; }
    }
}
