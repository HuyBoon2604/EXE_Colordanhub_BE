 using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Net.payOS.Types;
using Net.payOS;
using Booking_Dance_Bussiness.Services.Interfaces;
using Booking_Dance_Data.Models.Entities;

namespace Booking_Dance_Project_API.Controllers
{
    [Route("create-payment-link")]
    [ApiController]
    public class CheckOutPayOSController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IOrderService _orderService;
        private readonly IPaymentService _paymentService;

        public CheckOutPayOSController(IConfiguration configuration, IOrderService orderService, IPaymentService paymentService)
        {
            _configuration = configuration;
            _orderService = orderService;
            _paymentService = paymentService;

        }

        [HttpPost("{orderId}/checkout")]
        public async Task<IActionResult> Create(string orderId)
        {
            try
            {
                // Lấy thông tin order theo ID
                var order = await _orderService.GetOrderById(orderId);

                if (order == null)
                {
                    Console.WriteLine($"Không tìm thấy đơn hàng với ID: {orderId}");
                    return NotFound(new { error = "Không tìm thấy đơn hàng." });
                }

                // Kiểm tra thông tin số tiền
                if (order.TotalPrice <= 0 || order.TotalPrice > int.MaxValue)
                {
                    Console.WriteLine($"Amount không hợp lệ: {order.TotalPrice}");
                    return BadRequest(new { error = "Số tiền thanh toán không hợp lệ." });
                }

                int amountToPay = (int)Math.Round(order.TotalPrice);

                // Lấy thông tin cấu hình PayOS
                var clientId = _configuration["PayOS:ClientId"];
                var apiKey = _configuration["PayOS:ApiKey"];
                var checksumKey = _configuration["PayOS:ChecksumKey"];

                if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(checksumKey))
                {
                    return BadRequest(new { error = "Thông tin cấu hình PayOS bị thiếu hoặc không hợp lệ." });
                }

                // Khởi tạo PayOS với thông tin cấu hình
                var payOS = new PayOS(clientId, apiKey, checksumKey);
                var domain = "http://localhost:5173";

                // Chuyển đổi `orderCode` sang một giá trị hợp lệ
                var orderCode = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();


                var description = $"Thanh toán đơn {orderId}";
                if (description.Length > 25)
                {
                    description = description.Substring(0, 25); // Giới hạn 25 ký tự
                }

                // Cấu hình dữ liệu thanh toán
                var paymentLinkRequest = new PaymentData(

                     orderCode: Convert.ToInt64(orderCode),
                    amount: Convert.ToInt32(order.TotalPrice),
                    description: description,
                    items: [new(order.Description, 1, Convert.ToInt32(order.TotalPrice))],
                    returnUrl: $"{domain}/checkout-success",
                    //cancelUrl: $"{domain}/checkout-fail/?orderId={orderId}"
                    cancelUrl: $"{domain}/checkcancel"
                );

                // Gọi API để tạo liên kết thanh toán
                var response = await payOS.createPaymentLink(paymentLinkRequest);


                if (!string.IsNullOrEmpty(response.checkoutUrl))
                {
                    var payment = new Payment
                    {
                        Id = Guid.NewGuid().ToString(),
                        OrderId = orderId,
                        TransactionCode = orderCode,
                        Status = "Waiting",
                        TransDate = DateTime.UtcNow
                    };

                    await _paymentService.AddPayment(payment);

                    return Ok(response);
                }


                return StatusCode(500, new { error = "Không thể tạo liên kết thanh toán. Vui lòng thử lại." });
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Lỗi tạo liên kết thanh toán: {ex.Message}");
                return StatusCode(500, new { error = "Đã xảy ra lỗi trong quá trình xử lý thanh toán." });
            }
        }
        [HttpGet("update-status")]
        public async Task<IActionResult> UpdatePaymentStatus([FromQuery] string odercode, [FromQuery] string status)
        {
            try
            {

                await _paymentService.Updatestatuspayment(odercode, status);


                return Ok(new { message = "Payment status updated successfully." });
            }
            catch (InvalidOperationException ex)
            {

                return NotFound(new { error = ex.Message });
            }
            catch (ArgumentException ex)
            {

                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while updating payment status.", details = ex.Message });
            }
        }

        [HttpGet("update-status-2")]
        public async Task<IActionResult> UpdatePaymentStatus2([FromQuery] string odercode)
        {
            try
            {

                await _paymentService.UpdateStatusPayment2(odercode);


                return Ok(new { message = "Payment status updated successfully." });
            }
            catch (InvalidOperationException ex)
            {

                return NotFound(new { error = ex.Message });
            }
            catch (ArgumentException ex)
            {

                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "An error occurred while updating payment status.", details = ex.Message });
            }
        }
    }
}
