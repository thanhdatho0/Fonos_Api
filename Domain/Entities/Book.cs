using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book
    {
        public Guid BookId { get; set; } = new Guid();
        public string Title { get; set; } = string.Empty;
        public string? ISBN { get; set; }
        public Guid? PublisherId { get; set; }
        public int PublicationYear { get; set; }
        public string? Description { get; set; }
        public string CoverImageUrl { get; set; } = string.Empty;
        public int? PageCount { get; set; }
        public string Language { get; set; } = string.Empty;
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual Audiobook? Audiobook { get; set; }
        public virtual Publisher? Publisher { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; } = [];
        public virtual ICollection<UserPurchase> Purchases { get; set; } = [];
        public virtual ICollection<UserFavorite> Favorites { get; set; } = [];
        public virtual ICollection<PlaylistItem> PlaylistItems { get; set; } = [];
        public virtual ICollection<BookAuthor> BookAuthors { get; set; } = [];
        public virtual ICollection<BookCategory> BookCategories { get; set; } = [];

    }
}
