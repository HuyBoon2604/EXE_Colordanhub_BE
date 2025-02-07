using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Models.DTO.StudioDTO
{
    public class UpdateStudioDTO
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string ImageId { get; set; }
        public decimal Pricing { get; set; }
        public string StudioName { get; set; }
        public string StudioAddress { get; set; }
        public string StudioDescription { get; set; }
        public string ImageStudio { get; set; }
        public string StudioSize { get; set; }
        public string Capacity { get; set; }
    }
}
