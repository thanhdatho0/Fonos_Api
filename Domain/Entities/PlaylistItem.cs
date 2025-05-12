using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PlaylistItem
    {
        public Guid PlaylistItemId { get; set; } = new Guid();
        public DateTime AddedDate { get; set; }
        public string DisplayOrder { get; set; } = null!;
        public Guid UserPlaylistId { get; set; }
        public virtual UserPlaylist? UserPlaylist { get; set; }
        public Guid BookId { get; set; }
        public virtual Book? Book { get; set; }
        public virtual ICollection<UserListeningProgress> UserListeningProgresses { get; set; } = [];
    }
}
