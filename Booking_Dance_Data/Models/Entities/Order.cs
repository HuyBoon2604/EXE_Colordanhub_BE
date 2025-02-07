using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Models.Entities
{
    public class Order : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Id { get; set; }
        public string BookingId { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Status { get; set; }


        // Quan hệ N-1 với Booking
        public Booking Booking { get; set; }

        // Quan hệ 1-N với Payment
        public ICollection<Payment> Payments { get; set; }
    }


}
