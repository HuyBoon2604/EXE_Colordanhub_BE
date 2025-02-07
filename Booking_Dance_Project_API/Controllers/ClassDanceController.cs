using Booking_Dance_Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Dance_Project_API.Controllers
{
    public class ClassDanceController : Controller
    {  private readonly IClassDanceRepo _classDanceRepo;

        public ClassDanceController(IClassDanceRepo classDanceRepo)
        {
            _classDanceRepo = classDanceRepo;
        }

        [Route("Get-All-ClassDance")]
        [HttpGet]
        public async Task<IActionResult> GetAllClassDance()
        {
            try
            {
                var a = await _classDanceRepo.GetAllClassDancesAsync();
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Get-ClassDance-By-Id")]
        [HttpGet]
        public async Task<IActionResult> GetClassDanceById(string classId)
        {
            try
            {
                var a = await _classDanceRepo.GetClassDanceByIdAsync(classId);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
