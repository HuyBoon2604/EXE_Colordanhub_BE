using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Models.DTO.StudioDTO
{
    public class CreateStudioDTO
    {
        public decimal ?Pricing { get; set; }
        public string? StudioName { get; set; }
        public string ?StudioAddress { get; set; }
        public string ?StudioDescription { get; set; }
        //public string ?StudioSize { get; set; }
        //public string ?Capacity { get; set; }
    }
}
