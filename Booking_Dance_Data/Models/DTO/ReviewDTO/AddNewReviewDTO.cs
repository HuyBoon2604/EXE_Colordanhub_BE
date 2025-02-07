using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Models.DTO.ReviewDTO
{
    public class AddNewReviewDTO
    {
        public string ?AccountId { get; set; }
        public string ?StudioId { get; set; }
        public string ?ReviewComment { get; set; }
    }
}
