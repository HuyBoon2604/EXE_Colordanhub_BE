using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using System;

using System.Reflection.Metadata.Ecma335;
using Booking_Dance_Data.Models.Entities;
using Booking_Dance_Data;
using Booking_Dance_Data.Repository;
using Microsoft.AspNetCore.Http;
using Booking_Dance_Bussiness.Service.Interfaces;



namespace Booking_Dance_Bussiness
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly IAccountRepo _accountRepo;
        private readonly IFirebaseService _firebase;
        private readonly IMapper _mapper;


        public AccountService(IConfiguration configuration, IEmailService emailService, IAccountRepo accountRepo,IFirebaseService firebaseService,
            IMapper mapper)
        {
            _configuration = configuration;
            _emailService = emailService;
            _accountRepo = accountRepo;
            _mapper = mapper;
             _firebase = firebaseService;

        }


        private string CreateToken(Account account)
        {

            List<Claim> claims = new List<Claim>()
            {
                new Claim("RoleID", account.RoleId),
                new Claim("AccountID", account.Id),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;

        }

        public async Task<string> Login(LoginDTO request)
        {
            try
            {
                var user = await _accountRepo.checkuser(request.Email);
                if (user == null)
                    throw new Exception("USER IS NOT FOUND");
                if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                    throw new Exception("INVALID PASSWORD");
                //if (!user.Status)
                //    throw new Exception("ACCOUNT WAS BANNED OR DELETED");
                var token = CreateToken(user);
                return token;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Account> Registration(RegisterDTO request)
        {
            try
            {
                var r = new Account();
                if (request != null)
                {

                    var t = await _accountRepo.checkuser(request.Email);
                    if (t != null)
                    {
                        throw new Exception("UserName has been existted!");
                    }

                    r.Id = "AC" + Guid.NewGuid().ToString().Substring(0, 5);
                    r.UserName = request.Username;
                    r.Email = request.Email;
                    r.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
                    r.IsActive = true;
                    r.RoleId = request.RoleId;

                    await _accountRepo.AddAccountAsync(r);

                    return r;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }


        public async Task<bool> ForgotPasswordAsync(ForgotPasswordDTO forgotPasswordRequest)
        {
            var user = await _accountRepo.checkuser(forgotPasswordRequest.Email);
            if (user == null)
            {
                return false;
            }

            var token = CreateToken(user);

            var callbackUrl = $"http://localhost:5174/resetpass?email={forgotPasswordRequest.Email}&token={token}"; ;
            var message = $"Please reset your password by clicking here:{callbackUrl}";

            await _emailService.SendEmailAsync(forgotPasswordRequest.Email, "Reset Password", message);

            return true;
        }

        public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword)
        {
            var user = await _accountRepo.checkuser(email); ;
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return false;
            }

            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidAudience = _configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };

            try
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var principal = jwtTokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

                if (validatedToken is JwtSecurityToken jwtToken)
                {
                    var userIdClaim = principal.FindFirst("AccountID")?.Value;
                    if (userIdClaim == user.Id.ToString())
                    {
                        user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
                        await _accountRepo.UpdateAccountAsync(user);

                        return true;
                    }
                    else
                    {
                        Console.WriteLine("UserIdClaim does not match.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid token.");
                }
            }
            catch (SecurityTokenException ex)
            {
                Console.WriteLine($"Security token exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while validating the token: {ex.Message}");
            }

            return false;
        }



        public async Task<Account> DeleteAccount(string accountId)
        {
            try
            {
                var account = await _accountRepo.GetAccount(accountId);
                account.IsActive = false;
                account.DeleteAt = DateTime.UtcNow;
                await _accountRepo.UpdateAccountAsync(account);
                return account;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting account with Id {accountId}: {ex.Message}", ex);
            }
        }
        public async Task<Account> EnableAccount(string accountId)
        {
            try
            {
                var account = await _accountRepo.GetAccount(accountId);
                account.IsActive = true;
                account.DeleteAt = null;
                await _accountRepo.UpdateAccountAsync(account);
                return account;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Enable account with Id {accountId}: {ex.Message}", ex);
            }
        }
        public async Task<Account> GetById(string accountId)
        {
            try
            {
                var account = await _accountRepo.GetAccount(accountId);
                return account;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving account with Id {accountId}: {ex.Message}", ex);
            }
        }

        public async Task<List<Account>> GetAll()
        {
            try
            {
                var account = await _accountRepo.GetAllAccount();
                return account;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving account: {ex.Message}", ex);
            }
        }

        public async Task<Account> EditAccount(EditAccountDTO edit)
        {
            var Account = await _accountRepo.GetAccount(edit.Id);
            if (Account == null)
            {

                throw new Exception($" {edit.Id} khong ton tai:");
            }
            Account.Email = edit.email;
            Account.UserName = edit.UserName;
            Account.Phone = edit.Phone;
            Account.DateOfBirth = edit.DateOfBirth;

            await _accountRepo.UpdateAccountAsync(Account);


            return Account;
        }

        public async Task UpdateImageAccount(IFormFile poster, string accountId)
        {
            try
            {
                var avatar = await _accountRepo.GetAccount(accountId);
                if (avatar != null)
                {
                    var path = await _firebase.UploadImage(poster, "avatar_studio", avatar.Id);
                    var path2 = await _firebase.GetImagePath(path, "avatar_studio");
                     avatar.ImageUrl = path2;
                    await _accountRepo.UpdateAccountAsync(avatar);

                }
                else
                {
                    throw new KeyNotFoundException("courseId not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }
    }
}