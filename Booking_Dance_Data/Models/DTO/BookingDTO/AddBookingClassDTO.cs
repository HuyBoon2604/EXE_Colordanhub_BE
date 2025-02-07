using Booking_Dance_Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Booking_Dance_Data.Models.DTO.BookingDTO
{
    public class AddBookingClassDTO
    {

        [Required]
        public string AccountId { get; set; }
        [Required]

        public string ClassDanceId { get; set; }

        [Required]
        public string BookingDate { get; set; }

        //[Required]
        //public string CheckIn { get; set; }

        //[Required]
        //public string CheckOut { get; set; }

        public decimal TotalPrice { get; set; }

    }

}
