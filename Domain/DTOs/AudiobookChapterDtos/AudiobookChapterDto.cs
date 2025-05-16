using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.AudiobookChapterDtos
{
    public class AudiobookChapterDto
    {
        public Guid AudiobookChapterId { get; set; }
        public Guid AudiobookId { get; set; }
        public int ChapterNumber { get; set; }
        public string ChapterTitle { get; set; } = null!;
        public string Duration { get; set; } = null!;
        public string FileUrl { get; set; } = null!;
        public long? FileSize { get; set; }
    }
}
