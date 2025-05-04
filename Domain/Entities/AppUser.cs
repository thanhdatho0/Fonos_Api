
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime RefreshTokenExpiryTime { get; set; }
        public virtual ICollection<UserPurchase> Purchases { get; set; } = [];
        public virtual ICollection<UserListeningProgress> Progresses { get; set; } = [];
        public virtual ICollection<UserBookmark> Bookmarks { get; set; } = [];
        public virtual ICollection<UserFavorite> Favorites { get; set; } = [];
        public virtual ICollection<UserPlaylist> Playlists { get; set; } = [];
        public virtual ICollection<Rating> Ratings { get; set; } = [];
        public virtual ICollection<Download> Downloads { get; set; } = [];

    }
}
