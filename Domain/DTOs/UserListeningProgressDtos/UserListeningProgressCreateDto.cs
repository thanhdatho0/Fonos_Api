

namespace Domain.DTOs.UserListeningProgressDtos
{
    public class UserListeningProgressCreateDto
    {
        public string AppUserId { get; set; } = null!;
        public Guid AudiobookChapterId { get; set; }
        public int CurrentPosition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
