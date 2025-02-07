using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Models.Entities
{
    public class History : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Id { get; set; }
        public string PaymentId { get; set; }
        public string Day { get; set; }
        public DateTime Datetime { get; set; }
        [Precision(18, 2)]
        public decimal Pricing { get; set; }

        // Quan hệ N-1 với Payment
        public Payment Payment { get; set; }
    }


}
