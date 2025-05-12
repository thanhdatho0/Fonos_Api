

namespace Domain.DTOs.UserFavoriteDtos
{
    public class UserFavoriteCreateDto
    {
        public string AppUserId { get; set; } = null!;
        public Guid BookId { get; set; }
    }
}
