using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.AudiobookDtos
{
    public class AudiobookDto
    {
        public Guid AudiobookId { get; set; }
        public Guid? BookId { get; set; }
        public string Duration { get; set; } = null!;
        public long? FileSize { get; set; }
        public string AudioQuality { get; set; } = null!;
        public DateTime? ReleaseDate { get; set; }
        public bool IsComplete { get; set; }
        public int TotalChapters { get; set; }
    }
}
