using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Models.Entities
{
    public class Booking : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string? StudioId { get; set; }
        public string? ClassId { get; set; }
        public string? BookingDate { get; set; }
        public string? CheckIn { get; set; }
        public string? CheckOut { get; set; }
        [Precision(18, 2)]
        public decimal TotalPrice { get; set; }

        // Quan hệ N-1 với ClassDance
        [ForeignKey("ClassId")]
        public ClassDance ClassDance { get; set; }

        // Quan hệ N-1 với Account
        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        // Quan hệ N-1 với Studio
        [ForeignKey("StudioId")]

        public Studio Studio { get; set; }

        // Quan hệ 1-N với Order
        public ICollection<Order> Orders { get; set; }
    }


}
