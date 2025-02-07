using Booking_Dance_Bussiness.Services.Interfaces;
using Booking_Dance_Data.Models.Entities;
using Booking_Dance_Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Bussiness.Services.Implements
{
    public class ClassDanceService : IClassDanceService
    {
        private readonly IClassDanceRepo _classDanceRepo;

        public ClassDanceService(IClassDanceRepo classDanceRepo)
        {
            _classDanceRepo = classDanceRepo;
        }

        public Task<List<ClassDance>> GetAllClassDance()
        {
            return _classDanceRepo.GetAllClassDancesAsync();        
        }
    }
}
