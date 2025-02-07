
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.Extensions.Configuration;
using Booking_Dance_Data.Repositories;
using Booking_Dance_Data.Models.Entities;
using Booking_Dance_Data.Repository;
using Booking_Dance_Data.Context;


namespace Cursus.Repositories
{
    public class AccountRepo : BaseRepository<Account>, IAccountRepo
    {
        private readonly IConfiguration _configuration;

        private readonly BookingDanceContext _context;

        public AccountRepo(BookingDanceContext context, IConfiguration configuration) : base(context)
        {
            _context = context;
            _configuration = configuration;

        }

        public async Task AddAccountAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task<Account?> checkuser(string email)
        {
            return await _context.Accounts.Where(x => x.Email.Equals(email))
                                                  .Include(y => y.Role)
                                                  .SingleOrDefaultAsync();
        }


        public Account? FindById(string userId)
        {
            return _context.Accounts.Find(userId);
        }

        public async Task<Account?> FindByIdUserAsync(string id)
        {
            return await _context.Accounts.FindAsync(id);
        }


        public async Task<Account> UpdateAccountAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
            return account;
        }
        public async Task<Account> GetAccount(string id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Account>> GetAllAccount()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account?> CheckUserRole(string id)
        {
            return await _context.Accounts.Where(x => x.Id.Equals(id) && x.RoleId == "1") // Kiểm tra Role.Id = 1
                         .SingleOrDefaultAsync();
        }
    }
}
