using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.UserPurchaseDtos;
using Domain.Entities;

namespace DataAcces.EFCore.Mappers
{
    public static class UserPurchaseMappers
    {
        public static UserPurchaseDto ToUserPurchaseDto(this UserPurchase userPurchase)
        {
            return new UserPurchaseDto
            {
                UserPurchaseId = userPurchase.UserPurchaseId,
                AppUserId = userPurchase.AppUserId,
                BookId = userPurchase.BookId,
                PurchaseDate = userPurchase.PurchaseDate,
                PurchasePrice = userPurchase.PurchasePrice,
                PaymentMethod = userPurchase.PaymentMethod,
                TransactionId = userPurchase.TransactionId,
                PaymentStatus = userPurchase.PaymentStatus
            };
        }

        public static UserPurchaseDetailDto ToUserPurchaseDetailDto(this UserPurchase userPurchase)
        {
            return new UserPurchaseDetailDto
            {
                UserPurchaseId = userPurchase.UserPurchaseId,
                AppUserId = userPurchase.AppUserId,
                BookId = userPurchase.BookId,
                PurchaseDate = userPurchase.PurchaseDate,
                PurchasePrice = userPurchase.PurchasePrice,
                PaymentMethod = userPurchase.PaymentMethod,
                TransactionId = userPurchase.TransactionId,
                PaymentStatus = userPurchase.PaymentStatus,
                AppUser = userPurchase.AppUser?.ToAppUserDto(),
                Book = userPurchase.Book?.ToBookDto(),
            };
        }

        public static UserPurchase ToUserPurchaseFromCreateDto(this UserPurchaseCreateDto userPurchaseCreateDto)
        {
            return new UserPurchase
            {
                AppUserId = userPurchaseCreateDto.AppUserId,
                BookId = userPurchaseCreateDto.BookId,
                PurchaseDate = DateTime.UtcNow,
                PurchasePrice = userPurchaseCreateDto.PurchasePrice,
                PaymentMethod = userPurchaseCreateDto.PaymentMethod,
                TransactionId = userPurchaseCreateDto.TransactionId,
                PaymentStatus = userPurchaseCreateDto.PaymentStatus,
            };
        }
    }
}
