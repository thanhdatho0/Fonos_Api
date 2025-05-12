using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.AppUserDtos;
using Domain.DTOs.AudiobookDtos;

namespace Domain.DTOs.DownloadDtos
{
    public class DownloadDetailDto
    {
        public Guid DownloadId { get; set; }
        public string AppUserId { get; set; } = null!;
        public Guid AudiobookId { get; set; }
        public DateTime DownloadDate { get; set; }
        public string DeviceInfo { get; set; } = null!;
        public string IPAddress { get; set; } = null!;
        public AppUserDto? AppUser { get; set; }
        public AudiobookDto? Audiobook { get; set; }
    }
}
