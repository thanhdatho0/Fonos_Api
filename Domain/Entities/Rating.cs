using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Rating
    {
        public Guid RatingId { get; set; } = new Guid();
        public string AppUserId { get; set; } = string.Empty;
        public Guid BookId { get; set; }
        public double RatingValue { get; set; }
        public string? ReviewText { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }   
        public bool IsVisible { get; set; }
        public virtual AppUser? AppUser { get; set; }
        public virtual Book? Book { get; set; }
    }
}
