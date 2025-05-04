using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserPurchase
    {
        public Guid UserPurchaseId { get; set; } = new Guid();
        public string AppUserId { get; set; } = string.Empty;
        public Guid BookId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double PurchasePrice { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public Guid TransactionId { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
        public virtual AppUser? AppUser { get; set; }
        public virtual Book? Book { get; set; }

    }
}
