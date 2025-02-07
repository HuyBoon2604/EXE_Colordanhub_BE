using Booking_Dance_Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Models.DTO.OrderDTO
{
    public class GetOrder
    {
        public string Id { get; set; }
        public string BookingId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Status { get; set; }
        // Các thuộc tính từ Booking
        public string StudioId { get; set; }
        public string AccountId { get; set; }
        public string BookingDate { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public string Description { get; set; }
        public decimal TotalPrice { get; set; }


    }
}
