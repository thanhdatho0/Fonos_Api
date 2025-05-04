using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserFavorite
    {
        public Guid UserFavoriteId { get; set; } = new Guid();
        public string AppUserId { get; set; } = string.Empty;
        public Guid BookId { get; set; }
        public DateTime AddedDate { get; set; }
        public virtual AppUser? AppUser { get; set; }
        public virtual Book? Book { get; set; }
    }
}
