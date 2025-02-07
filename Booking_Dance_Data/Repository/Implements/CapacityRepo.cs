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
    public class CapacityRepo : BaseRepository<Capacity>, ICapacityRepo
    {
        private readonly BookingDanceContext _context;

        public CapacityRepo(BookingDanceContext context) : base(context)
        {
            _context = context;

        }
        public async Task AddCapacityAsync(Capacity capacity)
        {
            await _context.Capacities.AddAsync(capacity);
            await _context.SaveChangesAsync();
        }

        public async Task<Capacity> GetCapacityById(string CapacityId)
        {
            return await _context.Capacities.Include(x => x.Size).FirstOrDefaultAsync(s => s.Id == CapacityId);
        }
        public async Task<Capacity> GetCapacityByStudioId(string StudioId)
        {
            return await _context.Capacities
                   .Include(x => x.Size)
                   .Include(x => x.Studio)
                   .FirstOrDefaultAsync(s => s.StudioId == StudioId);
        }

        public async Task UpdateImageAsync(Capacity capacity)
        {
            _context.Capacities.Update(capacity);
            await _context.SaveChangesAsync();
        }
    }
}
