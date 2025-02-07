using Booking_Dance_Data.Models.Entities;
using Booking_Dance_Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Repository.Interfaces
{
    public interface ICapacityRepo : IBaseRepository<Capacity>
    {
        Task AddCapacityAsync(Capacity capacity);
        Task<Capacity> GetCapacityById(string CapacityId);
        Task UpdateImageAsync(Capacity capacity);
        Task<Capacity> GetCapacityByStudioId(string StudioId);
    }
}
