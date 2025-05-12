using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DTOs.UserBookmarkDtos
{
    public class UserBookmarkCreateDto
    {
        public string AppUserId { get; set; } = null!;
        public Guid AudiobookChapterId { get; set; }
        public string? Position { get; set; }
        public string BookmarkName { get; set; } = null!;
        public string Notes { get; set; } = null!;
    }
}
