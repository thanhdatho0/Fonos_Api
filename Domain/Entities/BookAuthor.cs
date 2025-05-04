using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BookAuthor
    {
        public Guid BookAuthorId { get; set; } = new();
        public Guid BookId { get; set; }
        public virtual Book? Book { get; set; }
        public Guid AuthorId { get; set; }
        public virtual Author? Author { get; set; }
    }
}
