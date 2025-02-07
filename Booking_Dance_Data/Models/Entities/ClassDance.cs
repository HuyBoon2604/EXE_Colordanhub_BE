using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Models.Entities
{
    public class ClassDance
    {
        [Required]
        [MaxLength(50)]
        public string Id { get; set; }
        public string StudioId { get; set; }
        public string? AccountId { get; set; }
        public string? ClassName { get; set; }
        public decimal? Pricing { get; set; }
        public string? Description { get; set; }
        public string? TimeStart { get; set; }
        public string? TimeEnd { get; set; }
        public string? DateStart { get; set; }
        public string? DateEnd{ get; set; }
        public string? DateOfWeek{ get; set; }


        // Quan hệ N-1 với Account
        public Studio? Studio { get; set; }

        // Quan hệ N-1 với Account
        public Account? Account { get; set; }

    }
}
