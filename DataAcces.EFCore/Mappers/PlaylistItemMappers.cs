using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.PlaylistItemDtos;
using Domain.Entities;

namespace DataAcces.EFCore.Mappers
{
    public static class PlaylistItemMappers
    {
        public static PlaylistItemDto ToPlaylistItemDto(this PlaylistItem playlistItem)
        {
            return new PlaylistItemDto
            {
                PlaylistItemId = playlistItem.PlaylistItemId,
                AddedDate = playlistItem.AddedDate,
                DisplayOrder = playlistItem.DisplayOrder,
                UserPlaylistId = playlistItem.UserPlaylistId,
                BookId = playlistItem.BookId,
            };
        }

        public static PlaylistItemDetailDto ToPlaylistItemDetailDto(this PlaylistItem playlistItem)
        {
            return new PlaylistItemDetailDto
            {
                PlaylistItemId = playlistItem.PlaylistItemId,
                AddedDate = playlistItem.AddedDate,
                DisplayOrder = playlistItem.DisplayOrder,
                UserPlaylistId = playlistItem.UserPlaylistId,
                BookId = playlistItem.BookId,
                UserPlaylist = playlistItem.UserPlaylist?.ToUserPlaylistDto(),
                Book = playlistItem.Book?.ToBookDto(),
            };
        }

        public static PlaylistItem ToPlaylistItemFromCreateDto(this PlaylistItemCreateDto playlistItemCreateDto)
        {
            return new PlaylistItem
            {
                AddedDate = DateTime.UtcNow,
                DisplayOrder = playlistItemCreateDto.DisplayOrder,
                UserPlaylistId = playlistItemCreateDto.UserPlaylistId,
                BookId = playlistItemCreateDto.BookId,
            };
        }
    }
}
