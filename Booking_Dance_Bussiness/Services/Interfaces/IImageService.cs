using Booking_Dance_Data.Models.DTO.ImageDTO;
using Booking_Dance_Data.Models.DTO.StudioDTO;
using Booking_Dance_Data.Models.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Bussiness.Services.Interfaces
{
    public interface IImageService
    {
        Task<Image> CreateImageAsync(IFormFile? poster1, IFormFile? poster2, IFormFile? poster3, IFormFile? poster4, IFormFile? poster5, CreateImageDTO createImageDTO, string accountId);
    }
}
