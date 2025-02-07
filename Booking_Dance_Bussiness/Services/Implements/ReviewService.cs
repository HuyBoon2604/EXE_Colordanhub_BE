using Booking_Dance_Bussiness.Services.Interfaces;
using Booking_Dance_Data.Models.DTO.ReviewDTO;
using Booking_Dance_Data.Models.Entities;
using Booking_Dance_Data.Repository.Implements;
using Booking_Dance_Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Bussiness.Services.Implements
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepo _reviewRepo;

        public ReviewService(IReviewRepo reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        public async Task<Review> CreateNewReview(AddNewReviewDTO addNewReviewDTO)
        {
            Review review = new Review();
            review.Id = "Rev" + Guid.NewGuid().ToString().Substring(0, 6);
            review.AccountId = addNewReviewDTO.AccountId;
            review.StudioId = addNewReviewDTO.StudioId;
            review.ReviewMessage = addNewReviewDTO.ReviewComment;
            review.Rating = 5;
            review.ReviewDate = DateTime.Now;
            await _reviewRepo.CreateReviewsAsync(review);
            return review;
        }
    }
}
