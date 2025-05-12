using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.PublisherDtos
{
    public class PublisherDto
    {
        public Guid PublisherId { get; set; }
        public string PublisherName { get; set; } = null!;
        public string? Description { get; set; }
        public string Website { get; set; } = null!;
        public int? FoundedYear { get; set; }
    }
}
