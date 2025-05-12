using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Author
    {
        public Guid AuthorId { get; set; } = new();
        public string AuthorName { get; set; } = null!;
        public string Biography { get; set; } = null!;
        public DateOnly? BirthDate { get; set; }
        public DateOnly? DeathDate { get; set; }
        public string Nationality { get; set; } = null!; 
        public string ImageUrl { get; set; } = null!;
        public virtual ICollection<BookAuthor> BookAuthors { get; set; } = [];
    }
}
