using Booking_Dance_Bussiness.Services.Interfaces;
using Booking_Dance_Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Dance_Project_API.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentRepo paymentRepo;

        public PaymentController(IPaymentRepo paymentRepo)
        {
            this.paymentRepo = paymentRepo;
        }

        [Route("Get-All-Payment")]
        [HttpGet]
        public async Task<IActionResult> GetAllPayment(string accountId)
        {
            try
            {
                var payments = await paymentRepo.GetAllPaymenByAccountId(accountId);
                if (payments != null)
                {
                    return Ok(payments);
                }
                return NotFound("Unable to get payments. ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
