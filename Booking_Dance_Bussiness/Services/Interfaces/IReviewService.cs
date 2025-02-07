using Booking_Dance_Data.Models.DTO.ReviewDTO;
using Booking_Dance_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Bussiness.Services.Interfaces
{
    public interface IReviewService
    {
        Task<Review> CreateNewReview(AddNewReviewDTO addNewReviewDTO);
    }
}
