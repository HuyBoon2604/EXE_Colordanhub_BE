using Booking_Dance_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Repository.Interfaces
{
    public interface IReviewRepo
    {
        Task<List<Review>> GetAllReviewsAsync();
        Task<List<Review>> GetAllReviewsByStudioIdAsync(string StudioId);
        Task CreateReviewsAsync(Review review);
    }
}
