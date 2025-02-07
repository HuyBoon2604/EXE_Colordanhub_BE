using Booking_Dance_Data.Models.DTO.OrderDTO;
using Booking_Dance_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Bussiness.Services.Interfaces
{
    public interface IOrderService
    {
        Task<GetOrder> GetOrderById(string id);
        Task<List<Order>> GetAllOrder();   
        Task<Order> CreateNewOrder(string BookingId);   
        Task<bool> DeleteOrderService(string OrderId);
        Task<bool> DeleteOrderServiceAndBooking(string orderId);
    }
}
