using Booking_Dance_Bussiness.Services.Interfaces;
using Booking_Dance_Data.Models.DTO.OrderDTO;
using Booking_Dance_Data.Models.Entities;
using Booking_Dance_Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Bussiness.Services.Implements
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IBookingRepo _bookingRepo;

        public OrderService(IOrderRepo orderRepo, IBookingRepo bookingRepo)
        {
            _orderRepo = orderRepo;
            _bookingRepo = bookingRepo; 
        }

        public async Task<Order> CreateNewOrder(string BookingId)
        {
            var getbooking= await _bookingRepo. GetBookingById(BookingId);  
            var getOrder = await _orderRepo.GetOrderByBookingId(BookingId);
            
           if (BookingId != null && getOrder == null)
            {
                Order order = new Order();  
                order.Id = "Ord"+Guid.NewGuid().ToString().Substring(0, 5);
                order.BookingId = BookingId; 
                order.OrderDate =DateTime.Now;
                order.Status = false;
                order.Description = "Account " + getbooking.AccountId +" Booking Success Studio: "+ getbooking.StudioId;
                await _orderRepo.AddOrder(order);
                return order;   
            }
            return null;
        }

        public async Task<bool> DeleteOrderService(string OrderId)
        {
            var getOrder = await _orderRepo.GetOrderId(OrderId);
             await _orderRepo.DeleteOrderAsync(getOrder);
            return true;
        }

        public async Task<bool> DeleteOrderServiceAndBooking(string orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
            {
                throw new ArgumentException("Order ID cannot be null or empty.", nameof(orderId));
            }

            // Xóa Order và Booking liên quan
            await _orderRepo.DeleteOrderWithBookingAsync(orderId);

            return true;
        }

        public async Task<List<Order>> GetAllOrder()
        {
           return await _orderRepo.GetAllOrder();
        }

      
        public async Task<GetOrder> GetOrderById(string id)
        {
            try
            {
                var order = await _orderRepo.GetOrderId(id);

                if (order == null)
                {
                    throw new KeyNotFoundException($"Order with ID: {id} not found.");
                }
                var getOrder = new GetOrder
                {
                    Id = order.Id,
                    BookingId = order.BookingId,
                    OrderDate = order.OrderDate,
                    Status = false,
                    StudioId = order.Booking.StudioId,
                    AccountId = order.Booking.AccountId,
                    BookingDate = order.Booking.BookingDate,
                    CheckIn = order.Booking.CheckIn,
                    CheckOut = order.Booking.CheckOut,
                    TotalPrice = order.Booking.TotalPrice,
                    Description = order.Description,
                };

                return getOrder;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }
    }
}
