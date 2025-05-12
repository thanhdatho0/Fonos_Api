using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DTOs.UserPurchaseDtos
{
    public class UserPurchaseCreateDto
    {
        public string AppUserId { get; set; } = null!;
        public Guid BookId { get; set; }
        public double PurchasePrice { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public Guid TransactionId { get; set; }
        public string PaymentStatus { get; set; } = null!;
    }
}
