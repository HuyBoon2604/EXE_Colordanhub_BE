using Booking_Dance_Bussiness.Services.Interfaces;
using Booking_Dance_Data.Models.Entities;
using Booking_Dance_Data.Repository;
using Booking_Dance_Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Bussiness.Services.Implements
{
    public class PaymentService : IPaymentService

    {
        private readonly IPaymentRepo repo;
        private readonly IOrderRepo _orderRepo;
        public PaymentService(IPaymentRepo paymentrepo, IOrderRepo orderRepo)
        {



            repo = paymentrepo;
            _orderRepo = orderRepo;
        }
        public async Task AddPayment(Payment payment)
        {
            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment), "Payment cannot be null.");
            }

            var existingPayment = await repo.GetPaymentByid(payment.Id);

            if (existingPayment == null)
            {
                await repo.AddPaymentAsync(payment);
            }
            else
            {

                throw new InvalidOperationException($"Payment with ID {payment.Id} already exists.");
            }
        }

      

        public async Task Updatestatuspayment(string ordercode, string status)
        {

            var payment = await repo.GetPaymentBytransactioncode(ordercode);


            if (payment == null)
            {
                throw new InvalidOperationException($"Payment with ID {ordercode} does not exist.");
            }


            if (status.Equals("success", StringComparison.OrdinalIgnoreCase))
            {
                payment.Status = "Pending";

            }
            else if (status.Equals("CANCELLED", StringComparison.OrdinalIgnoreCase))
            {
                payment.Status = "CANCELLED";

            }
            else
            {
                throw new ArgumentException($"Invalid status value: {status}. Accepted values are 'success' or 'cancel'.");
            }


            await repo.UpdatePayment(payment);

            Console.WriteLine($"Payment status for order {ordercode} updated to {payment.Status}");
        }

        public async Task UpdateStatusPayment2(string orderCode)
        {
            // Lấy thông tin Payment dựa trên mã giao dịch
            var payment = await repo.GetPaymentBytransactioncode(orderCode);

            // Nếu Payment không tồn tại, ném lỗi
            if (payment == null)
            {
                throw new InvalidOperationException($"Payment with transaction code {orderCode} does not exist.");
            }

            // Cập nhật trạng thái Payment thành "Success"
            payment.Status = "Success";

            payment.Order.Status = true; // Cập nhật trạng thái Order thành true

            // Lưu thay đổi vào cơ sở dữ liệu
            await repo.UpdatePayment(payment);

            // Log trạng thái sau khi cập nhật
            Console.WriteLine($"Payment status for order {orderCode} updated to {payment.Status}");
            if (payment.Order != null)
            {
                Console.WriteLine($"Order status for order {payment.Order.Id} updated to {payment.Order.Status}");
            }
        }
    }

}

