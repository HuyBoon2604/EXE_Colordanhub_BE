using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Models.Entities
{
    public class Payment : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Id { get; set; }
        public string OrderId { get; set; }

        public string TransactionCode { get; set; }
        public DateTime TransDate { get; set; }
        public string Status { get; set; }

        // Quan hệ N-1 với Order
        public Order Order { get; set; }

        // Quan hệ 1-N với History
        public ICollection<History> Histories { get; set; }
    }


}
