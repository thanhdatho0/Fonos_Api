using System;
using System.Collections.Generic;
using System.Linq;

using Domain.DTOs.AppUserDtos;
using Domain.DTOs.AudiobookChapterDtos;

namespace Domain.DTOs.UserListeningProgressDtos
{
    public class UserListeningProgressDetailDto
    {
        public Guid UserListeningProgressId { get; set; }
        public string AppUserId { get; set; } = null!;
        public Guid AudiobookChapterId { get; set; }
        public int CurrentPosition { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsCompleted { get; set; }
        public AppUserDto? AppUser { get; set; }
        public AudiobookChapterDto? AudiobookChapter { get; set; }
    }
}
