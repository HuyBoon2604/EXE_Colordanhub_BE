using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Models.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Id { get; set; }
        public string CategoryDescription { get; set; }

         //Quan hệ 1-N với các bảng khác
        //public ICollection<Studio> Studios { get; set; }
    }


}
