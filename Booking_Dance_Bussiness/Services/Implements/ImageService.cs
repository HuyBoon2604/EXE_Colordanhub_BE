using Booking_Dance_Bussiness.Service.Interfaces;
using Booking_Dance_Bussiness.Services.Interfaces;
using Booking_Dance_Data.Models.DTO.ImageDTO;
using Booking_Dance_Data.Models.Entities;
using Booking_Dance_Data.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking_Dance_Bussiness.Services.Implements
{
    public class ImageService : IImageService
    {
        private readonly IFirebaseService _firebaseService;
        private readonly IImageRepo _imageRepo;

        public ImageService(IFirebaseService firebaseService, IImageRepo imageRepo)
        {
            _firebaseService = firebaseService;
            _imageRepo = imageRepo;
        }

        public async Task<Image> CreateImageAsync(
     IFormFile? poster1, IFormFile? poster2, IFormFile? poster3, IFormFile? poster4, IFormFile? poster5,
     CreateImageDTO createImageDTO, string accountId)
        {
            var images = new List<(IFormFile?, string?)>
    {
        (poster1, createImageDTO?.ImageUrl1),
        (poster2, createImageDTO?.ImageUrl2),
        (poster3, createImageDTO?.ImageUrl3),
        (poster4, createImageDTO?.ImageUrl4),
        (poster5, createImageDTO?.ImageUrl5),
    };

            var imageUrls = new List<string?>();

            // Upload từng ảnh và lấy URL công khai
            foreach (var (poster, url) in images)
            {
                if (poster != null && !string.IsNullOrEmpty(url))
                {
                    try
                    {
                        string? path = await _firebaseService.UploadImage(poster, "studio", accountId);
                        string? imageUrl = await _firebaseService.GetImagePath(path, "studio");
                        imageUrls.Add(imageUrl);
                    }
                    catch (Exception ex)
                    {
                        // Log lỗi để xử lý sự cố sau này
                        Console.WriteLine($"Error uploading image: {ex.Message}");
                        imageUrls.Add(null);  // Thêm null vào nếu có lỗi trong quá trình tải ảnh
                    }
                }
                else
                {
                    imageUrls.Add(null);  // Thêm null vào nếu không có ảnh hoặc URL không hợp lệ
                }
            }

            // Tạo đối tượng Image
            var image = new Image
            {
                Id = "Img" + Guid.NewGuid().ToString().Substring(0, 5),
                StudioId = createImageDTO?.StudioId,  // Kiểm tra createImageDTO có thể null
                ImageUrl1 = imageUrls.ElementAtOrDefault(0),
                ImageUrl2 = imageUrls.ElementAtOrDefault(1),
                ImageUrl3 = imageUrls.ElementAtOrDefault(2),
                ImageUrl4 = imageUrls.ElementAtOrDefault(3),
                ImageUrl5 = imageUrls.ElementAtOrDefault(4),
            };

            // Kiểm tra null cho ImageUrl trước khi lưu vào database
            if (image.StudioId == null)
            {
                throw new ArgumentNullException(nameof(createImageDTO.StudioId), "StudioId cannot be null");
            }

            // Lưu vào database
            await _imageRepo.AddImageAsync(image);
            return image;
        }

    }
}