using Booking_Dance_Bussiness;
using Booking_Dance_Data;
using Booking_Dance_Data.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Dance_Project_API.Controllers
{
    public class ImageController : Controller
    {

        private readonly IImageRepo _imageRepo;

        public ImageController(IImageRepo imageRepo)
        {
            _imageRepo = imageRepo;
        }

        [AllowAnonymous]
        [Route("Get-All-Image-Of-Studio-By-StudioId")]
        [HttpGet]
        public async Task<IActionResult> GetAllImageOfStudioByStudioId(string StudioId)
        {
            try
            {
                var a = await _imageRepo.GetImagesById(StudioId);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
