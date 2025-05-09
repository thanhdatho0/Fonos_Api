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
        public string ChapterTitle { get; set; } = string.Empty;
        public int Duration { get; set; }
        public string FileUrl { get; set; } = string.Empty;
        public long? FileSize { get; set; }
    }
}
