using Booking_Dance_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Repository.Interfaces
{
    public interface IPaymentRepo
    {
        Task AddPaymentAsync(Payment payment);
        Task<List<Payment>> GetAllPaymenByAccountId(string accountId);
        Task<Payment> GetPaymentByid(string id);
        Task<Payment> GetPaymentByorderid(string orderid);
        Task<Payment> UpdatePayment(Payment payment);
        Task<Payment> GetPaymentBytransactioncode(string ordercode);
    }
}
