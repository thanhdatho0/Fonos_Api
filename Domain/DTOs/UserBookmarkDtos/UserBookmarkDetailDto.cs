using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.AppUserDtos;
using Domain.DTOs.AudiobookChapterDtos;
using Domain.Entities;

namespace Domain.DTOs.UserBookmarkDtos
{
    public class UserBookmarkDetailDto
    {
        public Guid UserBookmarkId { get; set; }
        public string AppUserId { get; set; } = null!;
        public Guid AudiobookChapterId { get; set; }
        public string? Position { get; set; }
        public string BookmarkName { get; set; } = null!;
        public string Notes { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public AppUserDto? AppUser { get; set; }
        public AudiobookChapterDto? AudiobookChapter { get; set; }
    }
}
