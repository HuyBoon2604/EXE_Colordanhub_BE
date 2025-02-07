using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Models.DTO.BookingDTO
{
    public class BookingByBookingIdDTO
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string? StudioId { get; set; }
        public string? ClassId { get; set; }
        public string? BookingDate { get; set; }
        public string? CheckIn { get; set; }
        public string? CheckOut { get; set; }
        [Precision(18, 2)]
        public decimal TotalPrice { get; set; }
        public string UserName { get; set; }
        public string? StudioName { get; set; }
        public string? StudioAddress { get; set; }
        public string? StudioDescription { get; set; }
        public string? ImageStudio { get; set; }
    }
}