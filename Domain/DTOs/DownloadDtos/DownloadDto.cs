using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.DownloadDtos
{
    public class DownloadDto
    {
        public Guid DownloadId { get; set; }
        public string AppUserId { get; set; } = null!;
        public Guid AudiobookId { get; set; }
        public DateTime DownloadDate { get; set; }
        public string DeviceInfo { get; set; } = null!;
        public string IPAddress { get; set; } = null!;
    }
}
