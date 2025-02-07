using Booking_Dance_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Booking_Dance_Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly BookingDanceContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(BookingDanceContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await Task.CompletedTask; // Since Update doesn't have an async version, return a completed Task
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return _dbSet.AsQueryable();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await Task.CompletedTask; // Since Delete doesn't have an async version, return a completed Task
        }

        public async Task<T?> FindAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
