using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Models.Entities
{
    public class Studio : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Id { get; set; }
        public string? AccountId { get; set; }
        public string? CategoryId { get; set; }
        public decimal? Pricing { get; set; }
        public string? StudioName { get; set; }
        public string? StudioAddress { get; set; }
        public string? StudioDescription { get; set; }
        public string? ImageStudio { get; set; }
        public string?  RatingId { get; set; }
      
        public Account? Account { get; set; }

       
        public Category? Category { get; set; }


        // Quan hệ 1-N với các bảng khác
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Voucher> Vouchers { get; set; }
        //public ICollection<Capacity> Capacities { get; set; }
    }

}
