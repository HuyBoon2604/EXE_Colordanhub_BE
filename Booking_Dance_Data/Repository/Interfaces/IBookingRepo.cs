using Booking_Dance_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Repository.Interfaces
{
    public interface IBookingRepo
    {
        Task AddBooking(Booking booking);  
        Task<List<Booking>> GetAllBooking();
        Task<Booking> GetBookingById(string id);
        Task<Booking?> GetBookingByOrderIdAsync(string orderId);
    }
}
