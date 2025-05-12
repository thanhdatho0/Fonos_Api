using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.UserBookmarkDtos;
using Domain.Entities;

namespace DataAcces.EFCore.Mappers
{
    public static class UserBookmarkMappers
    {
        public static UserBookmarkDto ToUserBookmarkDto(this UserBookmark userBookmark)
        {
            return new UserBookmarkDto
            {
                UserBookmarkId = userBookmark.UserBookmarkId,
                AppUserId = userBookmark.AppUserId,
                AudiobookChapterId = userBookmark.AudiobookChapterId,
                Position = userBookmark.Position,
                BookmarkName = userBookmark.BookmarkName,
                Notes = userBookmark.Notes,
                CreatedDate = userBookmark.CreatedDate,
            };
        }

        public static UserBookmarkDetailDto ToUserBookmarkDetailDto(this UserBookmark userBookmark)
        {
            return new UserBookmarkDetailDto
            {
                UserBookmarkId = userBookmark.UserBookmarkId,
                AppUserId = userBookmark.AppUserId,
                AudiobookChapterId = userBookmark.AudiobookChapterId,
                Position = userBookmark.Position,
                BookmarkName = userBookmark.BookmarkName,
                Notes = userBookmark.Notes,
                CreatedDate = userBookmark.CreatedDate,
                AppUser = userBookmark.AppUser?.ToAppUserDto(),
                AudiobookChapter = userBookmark.AudiobookChapter?.ToAudiobookChapter()
            };
        }

        public static UserBookmark ToUserBookmarkCreateDto(this UserBookmarkCreateDto userBookmarkCreateDto)
        {
            return new UserBookmark
            {
                AppUserId = userBookmarkCreateDto.AppUserId,
                AudiobookChapterId = userBookmarkCreateDto.AudiobookChapterId,
                Position = userBookmarkCreateDto.Position,
                BookmarkName = userBookmarkCreateDto.BookmarkName,
                Notes = userBookmarkCreateDto.Notes,
                CreatedDate = DateTime.UtcNow,
            };
        }
    }
}
