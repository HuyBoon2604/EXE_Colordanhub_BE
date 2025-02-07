using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Models.Entities
{
    public class Capacity : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Id { get; set; }

        public string? SizeId { get; set; }
        public string? StudioId { get; set; }

        public int? Quantity { get; set; } 

        // EF tự động hiểu đây là quan hệ N-1
        public Size? Size { get; set; }
        public Studio? Studio { get; set; }

    }
}
