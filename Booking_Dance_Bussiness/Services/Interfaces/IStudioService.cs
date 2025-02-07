using Booking_Dance_Data.Models.DTO.CapacityDTO;
using Booking_Dance_Data.Models.DTO.ImageDTO;
using Booking_Dance_Data.Models.DTO.StudioDTO;
using Booking_Dance_Data.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace Booking_Dance_Bussiness
{
    public interface IStudioService
    {
        Task<List<Studio>> ListAllStudio();
        Task<Studio> GetStudioById(string id);
        Task<Studio> CreateRequestStudio(CreateStudioDTO createStudioDTO);
        Task<Studio> CreateRequestStudio2(
      IFormFile? poster,
      IFormFile? poster1,
      IFormFile? poster2,
      IFormFile? poster3,
      IFormFile? poster4,
      IFormFile? poster5, CreateCapacityDTO createCapacityDTO,
      CreateStudioDTO createStudioDTO,

      string accountId);
        Task<Studio> UpdateRequestStudio(string studioID);
        Task<Studio> UpdateInfoStudio(UpdateStudioDTO updateStudioDTO);
        Task<List<Studio>> GetAllStudioWithIsActiveFalse(string accountId);
        Task<List<Studio>> GetAllStudioWithIsActiveTrue(string accountId);
        Task<Studio> GetStudioWithIsActiveFlaseById(string studioId);
    }

}