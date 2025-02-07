using Microsoft.AspNetCore.Mvc;

namespace Booking_Dance_Project_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExampleController : ControllerBase
    {
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("API is working!");
        }
    }
}
