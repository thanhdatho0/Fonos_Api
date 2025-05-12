

namespace Domain.DTOs.UserPlaylistDtos
{
    public class UserPlaylistDto
    {
        public Guid UserPlaylistId { get; set; }
        public string AppUserId { get; set; } = null!;
        public string PlaylistName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsPublic { get; set; }
    }
}
