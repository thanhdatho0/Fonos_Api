using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserBookmark
    {
        public Guid UserBookmarkId { get; set; } = new();
        public string AppUserId { get; set; } = null!;
        public Guid AudiobookChapterId { get; set; }
        public string? Position { get; set; }
        public string BookmarkName { get; set; } = null!;
        public string Notes { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public virtual AppUser? AppUser { get; set; }
        public virtual AudiobookChapter? AudiobookChapter { get; set; }
    }
}
