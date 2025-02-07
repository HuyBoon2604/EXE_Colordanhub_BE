 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Models.Entities
{
    public class Size
    {
        [Required]
        [MaxLength(50)]
        public string Id { get; set; }
        public string SizeDescription { get; set; }
      
    }

}
