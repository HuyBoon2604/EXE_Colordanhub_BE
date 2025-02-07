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
    public class ClassDanceRepocs : IClassDanceRepo
    {
        private readonly BookingDanceContext _bookingDanceContext;
        public ClassDanceRepocs(BookingDanceContext bookingDanceContext)
        {
            _bookingDanceContext = bookingDanceContext;
        }

        public async Task CreateClassAsync(ClassDance classDance)
        {
            await _bookingDanceContext.AddAsync(classDance);
            await _bookingDanceContext.SaveChangesAsync();   
        }

        public async Task<List<ClassDance>> GetAllClassDancesAsync()
        {
            return await _bookingDanceContext.ClassDances.ToListAsync();    
        }

        public async Task<ClassDance> GetClassDanceByIdAsync(string id)
        {
            return await _bookingDanceContext.ClassDances.FirstOrDefaultAsync(x=>x.Id == id);     
        }
    }
}
