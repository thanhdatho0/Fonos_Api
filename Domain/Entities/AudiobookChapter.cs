using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AudiobookChapter
    {
        public Guid AudiobookChapterId { get; set; } = new();
        public Guid AudiobookId { get; set; }
        public int ChapterNumber { get; set; }
        public string ChapterTitle { get; set; } = null!;
        public int Duration { get; set; }
        public string FileUrl { get; set; } = null!;
        public long? FileSize { get; set; }
        public virtual Audiobook? Audiobook { get; set; }
        public virtual UserListeningProgress? Progresses { get; set; }
        public virtual ICollection<UserBookmark> UserBookmarks { get; set; } = [];
    }
}
