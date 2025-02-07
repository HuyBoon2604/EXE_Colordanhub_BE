using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Models.Entities
{
    public class Noti : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Id { get; set; }
        public string NotiDescription { get; set; }
        public string AccountId { get; set; }

        // Quan hệ N-1 với Account
        public Account Account { get; set; }
    }

}
