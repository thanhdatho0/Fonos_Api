using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BookCategory
    {
        public Guid BookCategoryId { get; set; } = new();
        public Guid BookId { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Book? Book { get; set; }
        public virtual Category? Category { get; set; }
    }
}
