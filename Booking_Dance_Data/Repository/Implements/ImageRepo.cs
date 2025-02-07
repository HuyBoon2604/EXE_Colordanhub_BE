using Booking_Dance_Data.Context;
using Booking_Dance_Data.Models.Entities;
using Booking_Dance_Data.Repositories;
using Booking_Dance_Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Repository.Implements
{
    public class ImageRepo : BaseRepository<Image>, IImageRepo
    {

        private readonly BookingDanceContext _context;

        public ImageRepo(BookingDanceContext context) : base(context)
        {
            _context = context;

        }

        public async Task AddImageAsync(Image image)
        {
            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();
        }

        public async Task<Image> GetImagesById(string StudioId)
        {
            return await _context.Images.Include(x=>x.Studio).FirstOrDefaultAsync(s => s.StudioId == StudioId);
        }

        public async Task UpdateImageAsync(Image image)
        {
            _context.Images.Update(image);
            await _context.SaveChangesAsync();
        }
    }
}
