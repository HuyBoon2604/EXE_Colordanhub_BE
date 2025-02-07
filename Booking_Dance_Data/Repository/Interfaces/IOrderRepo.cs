using Booking_Dance_Data.Models.Entities;
using MailKit.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Repository.Interfaces
{
    public interface IOrderRepo
    {
        Task AddOrder(Order order);
        Task<Order?> GetOrderId(string id);
        Task<Order?> GetOrderByBookingId(string bookingid);
        Task<List<Order>> GetAllOrder();
        Task<List<Order>> GetOrdersByAccountIdSuccessAsync(string accountId);
        Task<List<Order>> GetOrdersByAccountIdAsync(string accountId);
        Task<List<Order>> GetOrdersByStudioIdSuccessAsync(string studioId);
        Task DeleteOrderAsync(Order order);
        Task DeleteOrderWithBookingAsync(string orderId);
            }
}
