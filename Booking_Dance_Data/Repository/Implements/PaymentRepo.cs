using Booking_Dance_Data.Context;
using Booking_Dance_Data.Models.Entities;
using Booking_Dance_Data.Repositories;
using Booking_Dance_Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Repository.Implements
{
    public class PaymentRepo : BaseRepository<Payment>, IPaymentRepo
    {
        private readonly BookingDanceContext context;
        public PaymentRepo(BookingDanceContext bookingDanceContext) : base(bookingDanceContext)
        {

            context = bookingDanceContext;


        }
        public async Task AddPaymentAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();

        }

        public async Task<Payment> GetPaymentByid(string id)
        {
            return await _context.Payments.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Payment> GetPaymentByorderid(string orderid)
        {
            return await _context.Payments.FirstOrDefaultAsync(x => x.OrderId == orderid);
        }

        public async Task<Payment> UpdatePayment(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
            return payment;
        }
        public async Task<Payment> GetPaymentBytransactioncode(string ordercode)
        {
            return await _context.Payments.Include(p => p.Order).FirstOrDefaultAsync(x => x.TransactionCode == ordercode);
        }

        public async Task<List<Payment>> GetAllPaymenByAccountId(string accountId)
        {
            if (string.IsNullOrWhiteSpace(accountId))
            {
                throw new ArgumentException("AccountId cannot be null or empty.", nameof(accountId));
            }

            return await _context.Payments
                .Include(p => p.Order)
                .ThenInclude(o => o.Booking)
                .Where(p => p.Order.Booking.AccountId == accountId)
                .ToListAsync();
        }
    }
}
