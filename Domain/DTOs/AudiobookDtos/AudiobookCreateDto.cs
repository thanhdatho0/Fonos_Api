using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.AudiobookDtos
{
    public class AudiobookCreateDto
    {
        public Guid? BookId { get; set; }
        public int Duration { get; set; }
        public long? FileSize { get; set; }
        public string AudioQuality { get; set; } = string.Empty;
        public DateTime? ReleaseDate { get; set; }
        public bool IsComplete { get; set; }
        public int TotalChapters { get; set; }
    }
}
