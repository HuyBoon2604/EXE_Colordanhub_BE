using Booking_Dance_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Repository.Interfaces
{
    public interface IClassDanceRepo
    {
        Task<List<ClassDance>> GetAllClassDancesAsync();    
        Task<ClassDance> GetClassDanceByIdAsync(string id);    
        Task CreateClassAsync(ClassDance classDance);    
    }
}
