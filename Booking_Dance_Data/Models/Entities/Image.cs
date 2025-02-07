using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Models.Entities
{
    public class Image : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Id { get; set; }
        public string? StudioId { get; set; }
        public string? ImageUrl1 { get; set; }
        public string? ImageUrl2 { get; set; }
        public string? ImageUrl3 { get; set; }
        public string? ImageUrl4 { get; set; }
        public string? ImageUrl5 { get; set; }

        [ForeignKey("StudioId")]
        public Studio Studio { get; set; }
    }
}
