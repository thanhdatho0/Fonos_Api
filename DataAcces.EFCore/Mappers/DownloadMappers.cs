using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.DownloadDtos;
using Domain.Entities;

namespace DataAcces.EFCore.Mappers
{
    public static class DownloadMappers
    {
        public static DownloadDto ToDownloadDto(this Download download)
        {
            return new DownloadDto
            {
                DownloadId = download.DownloadId,
                AppUserId = download.AppUserId,
                AudiobookId = download.AudiobookId,
                DownloadDate = download.DownloadDate,
                DeviceInfo = download.DeviceInfo,
                IPAddress = download.IPAddress,
            };
        }

        public static DownloadDetailDto ToDownloadDetailDto(this Download download)
        {
            return new DownloadDetailDto
            {
                DownloadId = download.DownloadId,
                AppUserId = download.AppUserId,
                AudiobookId = download.AudiobookId,
                DownloadDate = download.DownloadDate,
                DeviceInfo = download.DeviceInfo,
                IPAddress = download.IPAddress,
                AppUser = download.AppUser?.ToAppUserDto(),
                Audiobook = download.Audiobook?.ToAudiobookDto(),
            };
        }

        public static Download ToDownloadFromCreateDto(this DownloadCreateDto downloadCreate)
        {
            return new Download
            {
                AppUserId = downloadCreate.AppUserId,
                AudiobookId = downloadCreate.AudiobookId,
                DownloadDate = DateTime.UtcNow,
                DeviceInfo = downloadCreate.DeviceInfo,
                IPAddress = downloadCreate.IPAddress,
            };
        }
    }
}
