using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.UserListeningProgressDtos;
using Domain.Entities;

namespace DataAcces.EFCore.Mappers
{
    public static class UserListeningProgressMappers
    {
        public static UserListeningProgressDto ToUserListeningProgressDto(this UserListeningProgress userListeningProgress)
        {
            return new UserListeningProgressDto
            {
                UserListeningProgressId = userListeningProgress.UserListeningProgressId,
                AppUserId = userListeningProgress.AppUserId,
                AudiobookChapterId = userListeningProgress.AudiobookChapterId,
                CurrentPosition = userListeningProgress.CurrentPosition,
                LastUpdated = userListeningProgress.LastUpdated,
                IsCompleted = userListeningProgress.IsCompleted
            };
        }

        public static UserListeningProgressDetailDto ToUserListeningProgressDetailDto(this UserListeningProgress userListeningProgress)
        {
            return new UserListeningProgressDetailDto
            {
                UserListeningProgressId = userListeningProgress.UserListeningProgressId,
                AppUserId = userListeningProgress.AppUserId,
                AudiobookChapterId = userListeningProgress.AudiobookChapterId,
                CurrentPosition = userListeningProgress.CurrentPosition,
                LastUpdated = userListeningProgress.LastUpdated,
                IsCompleted = userListeningProgress.IsCompleted,
                AppUser = userListeningProgress.AppUser?.ToAppUserDto(),
                AudiobookChapter = userListeningProgress.AudiobookChapter?.ToAudiobookChapter()
            };
        }

        public static UserListeningProgress ToUserListeningProgressFromCreateDto(this UserListeningProgressCreateDto userListeningProgressCreate)
        {
            return new UserListeningProgress
            {
                AppUserId = userListeningProgressCreate.AppUserId,
                AudiobookChapterId = userListeningProgressCreate.AudiobookChapterId,
                CurrentPosition = userListeningProgressCreate.CurrentPosition,
                LastUpdated = DateTime.UtcNow,
                IsCompleted = userListeningProgressCreate.IsCompleted,
            };
        }
    }
}
