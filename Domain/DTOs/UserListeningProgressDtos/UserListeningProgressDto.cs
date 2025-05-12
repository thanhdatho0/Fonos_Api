

namespace Domain.DTOs.UserListeningProgressDtos
{
    public class UserListeningProgressDto
    {
        public Guid UserListeningProgressId { get; set; }
        public string AppUserId { get; set; } = null!;
        public Guid AudiobookChapterId { get; set; }
        public int CurrentPosition { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsCompleted { get; set; }
    }
}
