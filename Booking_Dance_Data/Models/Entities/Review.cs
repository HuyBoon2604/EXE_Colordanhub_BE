using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Models.Entities
{
    public class Review : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string StudioId { get; set; }
        public string? ReviewMessage { get; set; }
        public float? Rating { get; set; }
        public DateTime? ReviewDate { get; set; }

        // Quan hệ N-1 với Account
        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        // Quan hệ N-1 với Studio
        [ForeignKey("StudioId")]
        public Studio Studio { get; set; }
    }


}
