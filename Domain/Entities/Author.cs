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
        public string AuthorName { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public DateOnly? BirthDate { get; set; }
        public DateOnly? DeathDate { get; set; }
        public string Nationality { get; set; } = string.Empty; 
        public string ImageUrl { get; set; } = string.Empty;
        public virtual ICollection<BookAuthor> BookAuthors { get; set; } = [];
    }
}
