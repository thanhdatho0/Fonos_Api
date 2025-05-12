using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.UserFavoriteDtos;
using Domain.Entities;

namespace DataAcces.EFCore.Mappers
{
    public static class UserFavoriteMappers
    {
        public static UserFavoriteDto ToUserFavoriteDto(this UserFavorite userFavorite)
        {
            return new UserFavoriteDto
            {
                UserFavoriteId = userFavorite.UserFavoriteId,
                AppUserId = userFavorite.AppUserId,
                BookId = userFavorite.BookId,
                AddedDate = userFavorite.AddedDate,
            };
        }

        public static UserFavoriteDetailDto ToUserFavoriteDetailDto(this UserFavorite userFavorite)
        {
            return new UserFavoriteDetailDto
            {
                UserFavoriteId = userFavorite.UserFavoriteId,
                AppUserId = userFavorite.AppUserId,
                BookId = userFavorite.BookId,
                AddedDate = userFavorite.AddedDate,
                AppUser = userFavorite.AppUser?.ToAppUserDto(),
                Book = userFavorite.Book?.ToBookDto(),
            };
        }

        public static UserFavorite ToUserFavoriteFromCreateDto(this UserFavoriteCreateDto userFavoriteCreateDto)
        {
            return new UserFavorite
            {
                AppUserId = userFavoriteCreateDto.AppUserId,
                BookId = userFavoriteCreateDto.BookId,
                AddedDate = DateTime.UtcNow,
            };
        }
    }
}
