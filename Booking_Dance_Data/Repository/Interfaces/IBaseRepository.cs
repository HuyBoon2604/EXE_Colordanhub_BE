using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T?> FindAsync(int id);
        Task SaveAsync();
    }
}
