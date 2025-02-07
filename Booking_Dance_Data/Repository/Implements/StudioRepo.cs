using AutoMapper;
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
    public class StudioRepo : BaseRepository<Studio>, IStudioRepo
    {
        private readonly BookingDanceContext _context;

        public StudioRepo(BookingDanceContext context) : base(context)
        {
            _context = context;

        }

        public async Task AddStudioAsync(Studio studio)
        {
            await _context.Studios.AddAsync(studio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRequestStudioAsync(Studio studio)
        {
             _context.Studios.Update(studio);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Studio>> GetAllStudio()
        {
            return await _context.Studios.ToListAsync();
        }

        public async Task<List<Studio>> GetStudioByAddress(string address)
        {
            // Chuẩn hóa địa chỉ nhập vào
            string normalizedAddress = address.Replace(" ", "").ToLower();

            // Tìm studio khớp địa chỉ nhập
            return await _context.Studios
                .Where(stu => stu.StudioAddress != null &&
                              stu.StudioAddress.Replace(" ", "").ToLower().Contains(normalizedAddress))
                .ToListAsync();
        }

        public async Task<Studio> GetStudioById(string id)
        {
            return await _context.Studios.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Studio> GetStudioWithIsActiveFlaseById(string studioId)
        {
            return await _context.Studios.FirstOrDefaultAsync(s => s.Id == studioId && s.IsActive == false);
        }
        
        public async Task<Studio> GetStudioByNameAsync(string studioName)
        {
            return await _context.Studios.FirstOrDefaultAsync(s => s.StudioName == studioName);
        }


    }
}
