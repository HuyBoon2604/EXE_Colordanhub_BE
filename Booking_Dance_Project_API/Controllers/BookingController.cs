using Booking_Dance_Bussiness;
using Booking_Dance_Bussiness.Services.Interfaces;
using Booking_Dance_Data;
using Booking_Dance_Data.Models.DTO.BookingDTO;
using Booking_Dance_Data.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Dance_Project_API.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IBookingRepo _bookingRepo;

        public BookingController(IBookingService bookingService, IBookingRepo bookingRepo)
        {
            _bookingService = bookingService;
            _bookingRepo = bookingRepo;
        }

        [Route("Add-New-Booking")]
        [HttpPost]
        public async Task<IActionResult> AddNewBooking([FromBody] AddBookingDTO request)
        {
         
            try
            {
                var booking = await _bookingService.AddNewBooking(request);
                if (booking != null)
                {
                    return Ok(booking);
                }
                return NotFound("Unable to create booking. Studio or Account not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Route("Add-New-Booking-ClassDance")]
        [HttpPost]
        public async Task<IActionResult> AddNewBookingClassDance([FromBody] AddBookingClassDTO request)
        {

            try
            {
                var booking = await _bookingService.AddNewBookingClassDance(request);
                if (booking != null)
                {
                    return Ok(booking);
                }
                return NotFound("Unable to create booking. Studio or Account not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [Route("Get-All-Booking")]
        [HttpGet]
        public async Task<IActionResult> GetAllBooking()
        {
            try
            {
                var a = await _bookingRepo.GetAllBooking();
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("Get-Booking-By-OrderId")]
        [HttpGet]
        public async Task<IActionResult> GetBookingByOrderId(string OrderId)
        {
            try
            {
                var a = await _bookingRepo.GetBookingByOrderIdAsync(OrderId);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Get-Booking-By-BookingiD")]
        [HttpGet]
        public async Task<IActionResult> GetBookingByBookingId(string bookingid)
        {
            try
            {
                var a = await _bookingService.GetbookingByid(bookingid);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
