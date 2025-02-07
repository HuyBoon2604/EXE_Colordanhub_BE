using Booking_Dance_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Repository.Interfaces
{
    public interface IImageRepo
    {
        Task AddImageAsync(Image image);
        Task UpdateImageAsync(Image image);
        Task<Image> GetImagesById(string StudioId);
    }
}
