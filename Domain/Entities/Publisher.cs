using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Publisher
    {
        public Guid PublisherId { get; set; } = new();
        public string PublisherName { get; set; } = null!;
        public string? Description { get; set; }
        public string Website { get; set; } = null!;
        public int? FoundedYear { get; set; }
        public virtual ICollection<Book> Books { get; set; } = [];
    }
}
