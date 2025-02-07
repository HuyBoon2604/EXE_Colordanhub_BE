
using Booking_Dance_Data.Models.Entities;
using Booking_Dance_Data.Repositories;

namespace Booking_Dance_Data.Repository
{
    public interface IAccountRepo : IBaseRepository<Account>
    {
        Task<Account> checkuser(string email);
        Task<Account> CheckUserRole(string id);
        Task AddAccountAsync(Account account);
        Task<Account> UpdateAccountAsync(Account account);
        Task<Account?> FindByIdUserAsync(string id);
        Task<Account> GetAccount(string id);
        Task<List<Account>> GetAllAccount();
    }
}