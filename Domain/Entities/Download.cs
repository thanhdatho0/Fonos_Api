using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Download
    {
        public Guid DownloadId { get; set; } = new();
        public string AppUserId { get; set; } = null!;
        public Guid AudiobookId { get; set; }
        public DateTime DownloadDate { get; set; }
        public string DeviceInfo { get; set; } = null!;
        public string IPAddress { get; set; } = null!;
        public virtual AppUser? AppUser { get; set; }
        public virtual Audiobook? Audiobook { get; set; }
    }
}
