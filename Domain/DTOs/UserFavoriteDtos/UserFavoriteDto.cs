

namespace Domain.DTOs.UserFavoriteDtos
{
    public class UserFavoriteDto
    {
        public Guid UserFavoriteId { get; set; }
        public string AppUserId { get; set; } = null!;
        public Guid BookId { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
