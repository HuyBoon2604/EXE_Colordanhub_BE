using Booking_Dance_Bussiness.Services.Implements;
using Booking_Dance_Bussiness.Services.Interfaces;
using Booking_Dance_Data.Models.DTO.ReviewDTO;
using Booking_Dance_Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Dance_Project_API.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IReviewRepo _reviewRepo;

        public ReviewController(IReviewService reviewService, IReviewRepo reviewRepo)
        {
            _reviewService = reviewService;
            _reviewRepo = reviewRepo;   
        }


        [Route("Create-New-Review")]
        [HttpPost]
        
        public async Task<IActionResult> AddNewReview([FromBody] AddNewReviewDTO addNewReviewDTO)
        {
            try
            {
                var review = await _reviewService.CreateNewReview(addNewReviewDTO);
                if (review != null)
                {
                    return Ok(review);
                }
                return NotFound("Unable to create review. ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Route("Get-All-Review")]
        [HttpGet]
        public async Task<IActionResult> GetAllReview()
        {
            try
            {
                var review = await _reviewRepo.GetAllReviewsAsync();
                if (review != null)
                {
                    return Ok(review);
                }
                return NotFound("Unable to get all review. ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Route("Get-All-Review-By-StudioId")]
        [HttpGet]
        public async Task<IActionResult> GetAllReviewByStudioId(string studioId)
        {
            try
            {
                var review = await _reviewRepo.GetAllReviewsByStudioIdAsync(studioId);
                if (review != null)
                {
                    return Ok(review);
                }
                return NotFound("Unable to get all review. ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
