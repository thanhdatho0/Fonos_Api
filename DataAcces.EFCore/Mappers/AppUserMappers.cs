using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Domain.DTOs.AppUserDtos;
using Domain.Entities;

namespace DataAcces.EFCore.Mappers
{
    public static class AppUserMappers
    {
        public static AppUserDto ToAppUserDto(this AppUser user)
        {
            return new AppUserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                AvatarUrl = user.AvatarUrl,
                RegistrationDate = user.RegistrationDate,
                LastLoginDate = user.LastLoginDate,
                IsActive = user.IsActive,
                IsVerified = user.IsVerified,
            };
        }
    }
}
