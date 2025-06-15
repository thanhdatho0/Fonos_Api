using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.RatingDtos;
using Domain.Entities;

namespace DataAcces.EFCore.Mappers
{
    public static class RatingMappers
    {
        public static RatingDto ToRatingDto(this Rating rating)
        {
            return new RatingDto
            {
                RatingId = rating.RatingId,
                AppUserId = rating.AppUserId,
                BookId = rating.BookId,
                RatingValue = rating.RatingValue,
                ReviewText = rating.ReviewText,
                CreatedDate = rating.CreatedDate,
                UpdatedDate = rating.UpdatedDate,
                IsVisible = rating.IsVisible,
            };
        }

        public static RatingOfBookDto ToRatingOfBookDto(this Rating rating)
        {
            return new RatingOfBookDto
            {
                RatingValue = rating.RatingValue,
                ReviewText = rating.ReviewText,
                CreatedDate = rating.CreatedDate,
                UpdatedDate = rating.UpdatedDate,
                IsVisible = rating.IsVisible,
                AppUser = rating.AppUser!.ToAppUserDto(),
            };
        }

        public static RatingDetailDto ToRatingDeatailDto(this Rating rating)
        {
            return new RatingDetailDto
            {
                RatingId = rating.RatingId,
                AppUserId = rating.AppUserId,
                BookId = rating.BookId,
                RatingValue = rating.RatingValue,
                ReviewText = rating.ReviewText,
                CreatedDate = rating.CreatedDate,
                UpdatedDate = rating.UpdatedDate,
                IsVisible = rating.IsVisible,
                AppUser = rating.AppUser?.ToAppUserDto(),
                Book = rating.Book?.ToBookDto(),
            };
        }

        public static Rating ToRatingFromCreateDto(this RatingCreateDto ratingCreateDto)
        {
            return new Rating
            {
                AppUserId = ratingCreateDto.AppUserId,
                BookId = ratingCreateDto.BookId,
                RatingValue = ratingCreateDto.RatingValue,
                ReviewText = ratingCreateDto.ReviewText,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                IsVisible = ratingCreateDto.IsVisible,
            };
        }

    }
}
