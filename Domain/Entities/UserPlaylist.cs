using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserPlaylist
    {
        public Guid UserPlaylistId { get; set; } = new();
        public string AppUserId { get; set; } = string.Empty;
        public string PlaylistName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsPublic { get; set; }
        public virtual AppUser? AppUser { get; set; }
        public virtual ICollection<PlaylistItem> Items { get; set; } = [];

    }
}
