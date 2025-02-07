using Booking_Dance_Bussiness.Service.Interfaces;
using Booking_Dance_Bussiness.Services.Interfaces;
using Booking_Dance_Data;
using Booking_Dance_Data.Models.DTO.CapacityDTO;
using Booking_Dance_Data.Models.DTO.ImageDTO;
using Booking_Dance_Data.Models.DTO.StudioDTO;
using Booking_Dance_Data.Models.Entities;
using Booking_Dance_Data.Repository;
using Booking_Dance_Data.Repository.Implements;
using Booking_Dance_Data.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Bussiness.Services.Implements
{
    public class StudioService : IStudioService
    {
        private readonly IStudioRepo _studioRepo;
        private readonly IAccountRepo _accountRepo;
        private readonly IFirebaseService _firebaseService;
        private readonly IImageService _imageService;
        private readonly IImageRepo _imageRepo;
        private readonly ICapacityRepo _capacityRepo;

        public StudioService(IStudioRepo studioRepo, IAccountRepo accountRepo, IFirebaseService firebaseService, IImageService imageService, IImageRepo imageRepo, ICapacityRepo capacityRepo)
        {
            _studioRepo = studioRepo;
            _accountRepo = accountRepo;
            _firebaseService = firebaseService;
            _imageService = imageService;
            _imageRepo = imageRepo;
            _capacityRepo = capacityRepo;
        }

        public async Task<Studio> CreateRequestStudio(CreateStudioDTO createStudioDTO)
        {
            try
            {
                var getStudioExist = await _studioRepo.GetStudioByNameAsync(createStudioDTO.StudioName);

                if (getStudioExist == null)
                {
                    Studio studio = new Studio();
                    studio.Id = "Stu" + Guid.NewGuid().ToString().Substring(0, 6);
                    //studio.AccountId = createStudioDTO.AccountId;
                    //studio.ImageId = createStudioDTO.ImageId;
                    studio.Pricing = createStudioDTO.Pricing;
                    studio.StudioName = createStudioDTO.StudioName;
                    studio.StudioAddress = createStudioDTO.StudioAddress;
                    studio.StudioDescription = createStudioDTO.StudioDescription;
                    //studio.Capacity = createStudioDTO.Capacity;
                    //studio.StudioSize = createStudioDTO.StudioSize;
                    studio.IsActive = false;

                    await _studioRepo.AddStudioAsync(studio);
                    return studio;
                }
                return null;
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Studio> CreateRequestStudio2(
      IFormFile? poster,
      IFormFile? poster1,
      IFormFile? poster2,
      IFormFile? poster3,
      IFormFile? poster4,
      IFormFile? poster5, CreateCapacityDTO createCapacityDTO,
      CreateStudioDTO createStudioDTO,
      string accountId)
        {
            try
            {
                if (createStudioDTO == null)
                {
                    throw new ArgumentNullException(nameof(createStudioDTO), "CreateStudioDTO cannot be null");
                }
                if (createCapacityDTO == null)
                {
                    throw new ArgumentNullException(nameof(createCapacityDTO), "createCapacityDTO cannot be null");
                }


                var account = await _accountRepo.GetAccount(accountId);
                if (account == null)
                {
                    throw new ArgumentNullException(nameof(accountId), "Account not found");
                }

                var getStudioExist = await _studioRepo.GetStudioByNameAsync(createStudioDTO.StudioName);
                if (account.RoleId == "2" && getStudioExist == null)
                {
                    // Upload poster chính và lấy đường dẫn
                    string? path = await _firebaseService.UploadImage(poster, "studio", accountId);
                    string? pathImageStudio = await _firebaseService.GetImagePath(path, "studio");

                    // Khởi tạo đối tượng Studio
                    var studio = new Studio
                    {
                        Id = "Stu" + Guid.NewGuid().ToString().Substring(0, 5),
                        AccountId = accountId,
                        IsActive = false,
                        CreateAt = DateTime.UtcNow,
                        Pricing = createStudioDTO.Pricing,
                        StudioName = createStudioDTO.StudioName,
                        StudioAddress = createStudioDTO.StudioAddress,
                        StudioDescription = createStudioDTO.StudioDescription,
                        //Capacity = createStudioDTO.Capacity,
                        //StudioSize = createStudioDTO.StudioSize,
                        ImageStudio = pathImageStudio,
                    };

                    await _studioRepo.AddStudioAsync(studio);

                    //Add Capacity table

                    var capac = new Capacity
                    {
                        Id = "Capa" + Guid.NewGuid().ToString().Substring(0, 5),
                        StudioId = studio.Id,   
                        SizeId = createCapacityDTO.SizeId, 
                        Quantity = createCapacityDTO.Quantity,  
                    };
                    await _capacityRepo.AddCapacityAsync(capac);    

                    // Add Image table
                    string? imageUrl1 = poster1 != null ? await UploadAndGetImagePath(poster1, "studio", accountId) : null;
                    string? imageUrl2 = poster2 != null ? await UploadAndGetImagePath(poster2, "studio", accountId) : null;
                    string? imageUrl3 = poster3 != null ? await UploadAndGetImagePath(poster3, "studio", accountId) : null;
                    string? imageUrl4 = poster4 != null ? await UploadAndGetImagePath(poster4, "studio", accountId) : null;
                    string? imageUrl5 = poster5 != null ? await UploadAndGetImagePath(poster5, "studio", accountId) : null;

                    var image = new Image
                    {
                        Id = "Img" + Guid.NewGuid().ToString().Substring(0, 5),
                        StudioId = studio.Id,
                        ImageUrl1 = imageUrl1,
                        ImageUrl2 = imageUrl2,
                        ImageUrl3 = imageUrl3,
                        ImageUrl4 = imageUrl4,
                        ImageUrl5 = imageUrl5,
                        CreateAt = DateTime.UtcNow,
                    };
                    await _imageRepo.AddImageAsync(image);

                    return studio; // Trả về đối tượng Studio
                }
                else
                {
                    throw new UnauthorizedAccessException("Account does not have the required role to create a studio.");
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"ArgumentNullException: {ex.Message}");
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"UnauthorizedAccessException: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding studio: {ex.Message}");
                throw new Exception("Failed to add studio", ex);
            }

            throw new InvalidOperationException("Unexpected error occurred while creating a studio.");
        }

        private async Task<string?> UploadAndGetImagePath(IFormFile? file, string folder, string accountId)
        {
            if (file == null || file.Length == 0) return null;

            string? path = await _firebaseService.UploadImage(file, folder, accountId);
            return await _firebaseService.GetImagePath(path, folder);
        }


        public async Task<List<Studio>> GetAllStudioWithIsActiveFalse(string accountId)
        {
            try
            {
                var allStudios = await _studioRepo.GetAllStudio();
                return allStudios.Where(a => a.AccountId == accountId && a.IsActive == false).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception($"Error get studios: {ex.Message}", ex);
            }

        }

        public async Task<List<Studio>> GetAllStudioWithIsActiveTrue(string accountId)
        {
            try
            {
                var allStudios = await _studioRepo.GetAllStudio();
                return allStudios.Where(s => s.IsActive == true && s.AccountId == accountId).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception($"Error get studios: {ex.Message}", ex);
            }
        }

        public async Task<Studio> GetStudioById(string id)
        {
            try
            {
                return await _studioRepo.GetStudioById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error get studios: {ex.Message}", ex);
            }
        }

        public async Task<Studio> GetStudioWithIsActiveFlaseById(string studioId)
        {
            try
            {
                return await _studioRepo.GetStudioWithIsActiveFlaseById(studioId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error get studios: {ex.Message}", ex);
            }
        }

        public async Task<List<Studio>> ListAllStudio()
        {
            try
            {
                return await _studioRepo.GetAllStudio();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error get all studios: {ex.Message}", ex);
            }
        }

        public async Task<Studio> UpdateRequestStudio(string studioID)
        {
            try
            {
                var getstudioExist = await _studioRepo.GetStudioById(studioID);
                if (getstudioExist != null)
                {
                    getstudioExist.IsActive = true;
                    await _studioRepo.UpdateAsync(getstudioExist);
                    return getstudioExist;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error get all studios: {ex.Message}", ex);
            }
        }

        public async Task<Studio> UpdateInfoStudio(UpdateStudioDTO updateStudioDTO)
        {
            try
            {
                var checkStudio = await _studioRepo.GetStudioById(updateStudioDTO.Id);
                if (checkStudio != null) { 
                     
                }
                return checkStudio;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
