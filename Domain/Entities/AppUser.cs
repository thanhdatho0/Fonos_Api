
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string AvatarUrl { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }
        public string RefreshToken { get; set; } = null!;
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
