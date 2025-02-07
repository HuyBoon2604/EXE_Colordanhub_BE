using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Models.Entities
{
    public class Voucher : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string StudioId { get; set; }
        public string Code { get; set; }
        [Precision(18, 2)]
        public decimal Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }

        // Quan hệ N-1 với Account
        public Account Account { get; set; }

        // Quan hệ N-1 với Studio
        public Studio Studio { get; set; }
    }


}
