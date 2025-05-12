
using Domain.DTOs.AppUserDtos;
using Domain.DTOs.BookDtos;

namespace Domain.DTOs.UserFavoriteDtos
{
    public class UserFavoriteDetailDto
    {
        public Guid UserFavoriteId { get; set; }
        public string AppUserId { get; set; } = null!;
        public Guid BookId { get; set; }
        public DateTime AddedDate { get; set; }
        public AppUserDto? AppUser { get; set; }
        public BookDto? Book { get; set; }
    }
}
