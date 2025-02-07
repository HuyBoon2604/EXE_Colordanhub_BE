using Booking_Dance_Bussiness.Services.Interfaces;
using Booking_Dance_Data.Models.DTO.BookingDTO;
using Booking_Dance_Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Dance_Project_API.Controllers
{
    public class CapacityController : Controller
    {
        private readonly ICapacityRepo _capacityRepo;

        public CapacityController(ICapacityRepo capacityRepo)
        {
            _capacityRepo = capacityRepo;
        }

        [Route("Get-Capacity-By-StudioId")]
        [HttpGet]
        public async Task<IActionResult> GetCapacityByStudioId(string StudioId)
        {

            try
            {
                var Capacity = await _capacityRepo.GetCapacityByStudioId(StudioId);
                if (Capacity != null)
                {
                    return Ok(Capacity);
                }
                return NotFound("Unable to get Capacity.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
