
namespace Domain.Entities
{
    public class UserPlaylist
    {
        public Guid UserPlaylistId { get; set; } = new();
        public string AppUserId { get; set; } = null!;
        public string PlaylistName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsPublic { get; set; }
        public virtual AppUser? AppUser { get; set; }
        public virtual ICollection<PlaylistItem> Items { get; set; } = [];

    }
}
