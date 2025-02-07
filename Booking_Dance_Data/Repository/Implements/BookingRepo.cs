using Booking_Dance_Data.Context;
using Booking_Dance_Data.Models.Entities;
using Booking_Dance_Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Repository.Implements
{
    public class BookingRepo : IBookingRepo
    {
        private readonly BookingDanceContext _context;

        public BookingRepo(BookingDanceContext context)
        {
            _context = context;
        }

        public async Task AddBooking(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Booking>> GetAllBooking()
        {
          return await _context.Bookings.ToListAsync();
        }


        public async Task<Booking?> GetBookingByOrderIdAsync(string orderId)
        {
            return await _context.Bookings
                .Include(b => b.Orders)
                .FirstOrDefaultAsync(b => b.Orders.Any(o => o.Id == orderId));
        }

        public async Task<Booking> GetBookingById(string id)
        {
            return await _context.Bookings.Include(x => x.Account).Include(x => x.Studio).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
