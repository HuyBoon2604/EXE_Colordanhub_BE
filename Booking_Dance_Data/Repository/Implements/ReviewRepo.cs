using Booking_Dance_Data.Context;
using Booking_Dance_Data.Models.Entities;
using Booking_Dance_Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Repository.Implements
{
    public class ReviewRepo : IReviewRepo
    {

        private readonly BookingDanceContext _bookingDanceContext;
        public ReviewRepo(BookingDanceContext bookingDanceContext)
        {
            _bookingDanceContext = bookingDanceContext;
        }

        public async Task CreateReviewsAsync(Review review)
        {

            await _bookingDanceContext.Reviews.AddAsync(review);
            await _bookingDanceContext.SaveChangesAsync();
        }

        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await _bookingDanceContext.Reviews.ToListAsync();
        }

        public async Task<List<Review>> GetAllReviewsByStudioIdAsync(string StudioId)
        {
            return await _bookingDanceContext.Reviews.Include(rv=>rv.Account).Where(rv => rv.StudioId == StudioId).ToListAsync();

        }
    }
}
