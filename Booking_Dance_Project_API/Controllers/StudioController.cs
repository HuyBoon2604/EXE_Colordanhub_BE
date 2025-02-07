using Booking_Dance_Bussiness;
using Booking_Dance_Bussiness.Services.Implements;
using Booking_Dance_Data.Models.DTO.CapacityDTO;
using Booking_Dance_Data.Models.DTO.ImageDTO;
using Booking_Dance_Data.Models.DTO.StudioDTO;
using Booking_Dance_Data.Models.Entities;
using Booking_Dance_Data.Repository.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Booking_Dance_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudioController : ControllerBase
    {
        private readonly IStudioService _studio;
        private readonly IStudioRepo _studioRepo;

        public StudioController(IStudioService studio, IStudioRepo studioRepo)
        {
            _studio = studio;
            _studioRepo = studioRepo;
        }

        [HttpGet("Get-All_Studio")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _studio.ListAllStudio();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-Studio-By-Id")]
        public async Task<IActionResult> GetStudioById(string id)
        {
            try
            {
                var result = await _studio.GetStudioById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-All-Studio-By-Address")]
        public async Task<IActionResult> GetStudioByAddress(string address)
        {
            try
            {
                var result = await _studioRepo.GetStudioByAddress(address);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-All-Studio-With-IsActive-False")]
        public async Task<IActionResult> GetAllStudioWithIsActiveFalse(string accountId)
        {
            try
            {
                var result = await _studio.GetAllStudioWithIsActiveFalse(accountId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-Studio-With-IsActive-False-By-Id")]
        public async Task<IActionResult> GetStudioWithIsActiveFlaseById(string studioId)
        {
            try
            {
                var result = await _studio.GetStudioWithIsActiveFlaseById(studioId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-All-Studio-With-IsActive-True")]
        public async Task<IActionResult> GetAllStudioWithIsActiveTrue(string accountId)
        {
            try
            {
                var result = await _studio.GetAllStudioWithIsActiveTrue(accountId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create-Request-Studio")]
        public async Task<IActionResult> CreateRequestStudio([FromBody] CreateStudioDTO createStudioDTO)
        {
            try
            {
                var result = await _studio.CreateRequestStudio(createStudioDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create-Request-Studio-With-Image")]

        public async Task<IActionResult> CreateRequestStudio2(
          IFormFile? poster,
      IFormFile? poster1,
      IFormFile? poster2,
      IFormFile? poster3,
      IFormFile? poster4,
      IFormFile? poster5, [FromForm]CreateCapacityDTO createCapacityDTO,
      [FromForm] CreateStudioDTO createStudioDTO,
      string accountId
     )
        {
            try
            {
                var result = await _studio.CreateRequestStudio2(poster, poster1, poster2, poster3, poster4, poster5, createCapacityDTO, createStudioDTO, accountId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("Update-Status-Request-Studio")]
        public async Task<IActionResult> UpdateStatusRequestStudio(string studioId)
        {
            try
            {
                var result = await _studio.UpdateRequestStudio(studioId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
