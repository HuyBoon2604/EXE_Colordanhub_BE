using Booking_Dance_Data.Context;
using Booking_Dance_Data.Models.Entities;
using Booking_Dance_Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Org.BouncyCastle.Asn1;

namespace Booking_Dance_Data.Repository.Implements
{
    public class OrderRepo : IOrderRepo
    {
        private readonly BookingDanceContext _bookingDanceContext;
        private readonly IMapper _mapper;
        public OrderRepo(BookingDanceContext bookingDanceContext, IMapper mapper)
        {
            _bookingDanceContext = bookingDanceContext;
            _mapper = mapper;
        }

        public async Task AddOrder(Order order)
        {
            await _bookingDanceContext.Orders.AddAsync(order);
            await _bookingDanceContext.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(Order order)
        {
            _bookingDanceContext.Remove(order);
            await _bookingDanceContext.SaveChangesAsync();
        }

        public async Task DeleteOrderWithBookingAsync(string orderId)
        {
            // Tìm Order kèm Booking liên quan
            var order = await _bookingDanceContext.Orders
                .Include(o => o.Booking) // Load Booking liên quan
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                throw new InvalidOperationException($"Order with ID {orderId} not found.");
            }

            // Lấy Booking liên quan
            var booking = order.Booking;

            // Xóa Booking nếu tồn tại
            if (booking != null)
            {
                _bookingDanceContext.Bookings.Remove(booking);
            }

            // Xóa Order
            _bookingDanceContext.Orders.Remove(order);

            // Lưu các thay đổi
            await _bookingDanceContext.SaveChangesAsync();
        }

        public Task<List<Order>> GetAllOrder()
        {
            return _bookingDanceContext.Orders.Include(x => x.Booking).ToListAsync();
        }

        public async Task<Order?> GetOrderId(string id)
        {
            return _bookingDanceContext.Orders.Include(x => x.Booking).FirstOrDefault(o => o.Id == id);
        }
        public async Task<Order?> GetOrderByBookingId(string bookingid)
        {
            return _bookingDanceContext.Orders.Include(x => x.Booking).FirstOrDefault(o => o.BookingId == bookingid && o.Status == true);
        }

        public async Task<List<Order>> GetOrdersByAccountIdSuccessAsync(string accountId)
        {
            return await _bookingDanceContext.Orders
                .Include(order => order.Booking)
                    .ThenInclude(booking => booking.Studio) // Bao gồm thông tin Studio
                .Where(order => order.Status == true
                                && order.Booking != null
                                && order.Booking.AccountId == accountId)
                .Select(order => new Order
                {
                    Id = order.Id,
                    Status = order.Status,
                    OrderDate = order.OrderDate,
                    BookingId = order.BookingId,
                    Description = order.Description,
                    Booking = new Booking
                    {
                        AccountId = order.Booking.AccountId,
                        Studio = new Studio
                        {
                            //Capacity = order.Booking.Studio.Capacity,
                            //StudioSize = order.Booking.Studio.StudioSize,
                            ImageStudio = order.Booking.Studio.ImageStudio,
                            Pricing = order.Booking.Studio.Pricing,
                            StudioName = order.Booking.Studio.StudioName,
                            StudioAddress = order.Booking.Studio.StudioAddress,
                        }
                    }
                })
                .ToListAsync();
        }


        public async Task<List<Order>> GetOrdersByStudioIdSuccessAsync(string studioId)
        {
            return await _bookingDanceContext.Orders
                .Include(o => o.Booking)
                .Where(order => order.Status == true
                                && order.Booking != null
                                && order.Booking.StudioId == studioId).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByAccountIdAsync(string accountId)
        {
            return await _bookingDanceContext.Orders
                           .Include(o => o.Booking)
                           .Where(order => order.Booking != null
                                           && order.Booking.AccountId == accountId).ToListAsync();
        }


    }
}
