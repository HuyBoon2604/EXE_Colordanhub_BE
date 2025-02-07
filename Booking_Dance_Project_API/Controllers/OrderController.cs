using Booking_Dance_Bussiness.Services.Interfaces;
using Booking_Dance_Data.Models.DTO.BookingDTO;
using Booking_Dance_Data.Models.DTO.OrderDTO;
using Booking_Dance_Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Dance_Project_API.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderRepo _orderRepo;

        public OrderController(IOrderService orderService, IOrderRepo orderRepo)
        {
            _orderService = orderService;
            _orderRepo = orderRepo;
        }

        [Route("Create-New-Order")]
        [HttpPost]
        public async Task<IActionResult> AddNewOrder(string BookingId)
        {
            try
            {
                var order = await _orderService.CreateNewOrder(BookingId);
                if (order != null)
                {
                    return Ok(order);
                }
                return NotFound("Unable to create order. ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Route("Get-Order-Id")]
        [HttpGet]
        public async Task<IActionResult> GetOrderId(string id)
        {

            try
            {
                var order = await _orderService.GetOrderById(id);
                if (order != null)
                {
                    return Ok(order);
                }
                return NotFound("can not find order. ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Route("Get-All-Order")]
        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {

            try
            {
                var order = await _orderService.GetAllOrder();
                if (order != null)
                {
                    return Ok(order);
                }
                return NotFound("can not find order. ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Route("Get-All-Order-Success-By-AccounId")]
        [HttpGet]
        public async Task<IActionResult> GetOrdersByAccountIdSuccessAsync(string accountId)
        {

            try
            {
                var order = await _orderRepo.GetOrdersByAccountIdSuccessAsync(accountId);
                if (order != null)
                {
                    return Ok(order);
                }
                return NotFound("can not find order. ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Route("Get-All-Order-Success-By-StudioId")]
        [HttpGet]
        public async Task<IActionResult> GetOrdersByStudioIdSuccessAsync(string studioId)
        {

            try
            {
                var order = await _orderRepo.GetOrdersByStudioIdSuccessAsync(studioId);
                if (order != null)
                {
                    return Ok(order);
                }
                return NotFound("can not find orders. ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Route("Get-All-Order-By-AccountId")]
        [HttpGet]
        public async Task<IActionResult> GetOrdersByAccountId(string accountId)
        {

            try
            {
                var order = await _orderRepo.GetOrdersByAccountIdAsync(accountId);
                if (order != null)
                {
                    return Ok(order);
                }
                return NotFound("can not find orders. ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Route("Delete-Order-By-OrderId")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderByOrderId(string orderID)
        {

            try
            {
                var order = await _orderService.DeleteOrderService(orderID);
                if (order != null)
                {
                    return Ok(order);
                }
                return NotFound("can not delete order. ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Route("Delete-Order-And-Booking-By-OrderId")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderAndBookingByOrderId(string orderID)
        {

            try
            {
                var order = await _orderService.DeleteOrderServiceAndBooking(orderID);
                if (order != null)
                {
                    return Ok(order);
                }
                return NotFound("can not delete order. ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
