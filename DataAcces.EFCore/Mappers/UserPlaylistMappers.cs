
using Domain.DTOs.UserPlaylistDtos;
using Domain.Entities;

namespace DataAcces.EFCore.Mappers
{
    public static class UserPlaylistMappers
    {
        public static UserPlaylistDto ToUserPlaylistDto(this UserPlaylist userPlaylist)
        {
            return new UserPlaylistDto
            {
                UserPlaylistId = userPlaylist.UserPlaylistId,
                AppUserId = userPlaylist.AppUserId,
                PlaylistName = userPlaylist.PlaylistName,
                Description = userPlaylist.Description,
                CreatedDate = userPlaylist.CreatedDate,
                UpdatedDate = userPlaylist.UpdatedDate,
                IsPublic = userPlaylist.IsPublic
            };
        }

        public static UserPlaylistDetailDto ToUserPlaylistDetailDto(this UserPlaylist userPlaylist)
        {
            return new UserPlaylistDetailDto
            {
                UserPlaylistId = userPlaylist.UserPlaylistId,
                AppUserId = userPlaylist.AppUserId,
                PlaylistName = userPlaylist.PlaylistName,
                Description = userPlaylist.Description,
                CreatedDate = userPlaylist.CreatedDate,
                UpdatedDate = userPlaylist.UpdatedDate,
                IsPublic = userPlaylist.IsPublic,
                AppUser = userPlaylist.AppUser?.ToAppUserDto(),
            };
        }

        public static UserPlaylist ToUserPlaylistCreateDto(this UserPlaylistCreateDto userPlaylistCreateDto)
        {
            return new UserPlaylist
            {
                AppUserId = userPlaylistCreateDto.AppUserId,
                PlaylistName = userPlaylistCreateDto.PlaylistName,
                Description = userPlaylistCreateDto.Description,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                IsPublic = userPlaylistCreateDto.IsPublic,
            };
        }
    }
}
