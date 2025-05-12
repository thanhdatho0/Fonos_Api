using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DTOs.UserPurchaseDtos
{
    public class UserPurchaseDto
    {
        public Guid UserPurchaseId { get; set; }
        public string AppUserId { get; set; } = null!;
        public Guid BookId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double PurchasePrice { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public Guid TransactionId { get; set; }
        public string PaymentStatus { get; set; } = null!;
    }
}
