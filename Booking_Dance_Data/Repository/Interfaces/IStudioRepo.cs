using Booking_Dance_Data.Models.Entities;
using Booking_Dance_Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Repository.Interfaces
{
    public interface IStudioRepo : IBaseRepository<Studio>
    {
        Task<List<Studio>> GetAllStudio();
        Task<Studio> GetStudioById(string id);    
        Task<List<Studio>> GetStudioByAddress(string address);    
        Task AddStudioAsync(Studio studio);
        Task UpdateRequestStudioAsync(Studio studio);
        Task<Studio> GetStudioWithIsActiveFlaseById(string studioId);
        Task<Studio> GetStudioByNameAsync(string studioName);
    }
}
