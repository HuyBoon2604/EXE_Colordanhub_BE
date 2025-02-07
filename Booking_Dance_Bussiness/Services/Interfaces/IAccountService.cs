using Booking_Dance_Data;
using Booking_Dance_Data.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace Booking_Dance_Bussiness
{
    public interface IAccountService
    {

        Task<Account> Registration(RegisterDTO request);
        Task<string> Login(LoginDTO request);
        Task<bool> ForgotPasswordAsync(ForgotPasswordDTO forgotPasswordRequest);
        Task<bool> ResetPasswordAsync(string email, string token, string newPassword);
        Task<Account> EditAccount(EditAccountDTO edit);
        Task UpdateImageAccount(IFormFile poster, string accountId);
        Task<Account> DeleteAccount(string accountId);
        Task<Account> GetById(string id);
        Task<Account> EnableAccount(string accountId);
        Task<List<Account>> GetAll();


    }
}