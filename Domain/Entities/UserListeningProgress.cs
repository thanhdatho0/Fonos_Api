using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserListeningProgress
    {
        public Guid UserListeningProgressId { get; set; } = new();
        public string AppUserId { get; set; } = string.Empty;
        public Guid AudiobookChapterId { get; set; }
        public int CurrentPosition { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsCompleted { get; set; }
        public virtual AppUser? AppUser { get; set; }
        public virtual AudiobookChapter? AudiobookChapter { get; set; }
    }
}
