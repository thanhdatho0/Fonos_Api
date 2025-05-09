using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.PublisherDtos
{
    public class PublisherDto
    {
        public Guid PublisherId { get; set; } = new();
        public string PublisherName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Website { get; set; } = string.Empty;
        public int? FoundedYear { get; set; }
    }
}
