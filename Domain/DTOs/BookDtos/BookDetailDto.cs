using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.AudiobookDtos;
using Domain.DTOs.PublisherDtos;
using Domain.Entities;

namespace Domain.DTOs.BookDtos
{
    public class BookDetailDto
    {
        public Guid BookId { get; set; }
        public string CoverImageUrl { get; set; } = null!;
        public string? Description { get; set; }
        public string Title { get; set; } = null!;
        public string? ISBN { get; set; }
        public int PublicationYear { get; set; }
        public int? PageCount { get; set; }
        public string Language { get; set; } = null!;
        public double Price { get; set; }
        public double Rating { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public AudiobookDto? Audiobook { get; set; }
        public PublisherDto? Publisher { get; set; }
    }
}
