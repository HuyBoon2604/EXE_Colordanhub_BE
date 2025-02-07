using Booking_Dance_Bussiness;
using Booking_Dance_Data;
using Booking_Dance_Data.Context;
using Booking_Dance_Data.Models.Entities;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Booking_Dance_Project_API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly BookingDanceContext _context;

        private readonly IAccountService account;
        private readonly IConfiguration _configuration;

        public AccountController(IAccountService account, IConfiguration configuration, BookingDanceContext bookingDanceContext)
        {
            this.account = account;
            _configuration = configuration;
            _context = bookingDanceContext; 
        }

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginRequest request)
        {
            try
            {
                // Xác minh Google Token
                var payload = await GoogleJsonWebSignature.ValidateAsync(request.Token, new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = new[] { _configuration["GoogleAuth:ClientId"] }
                });

                // Tìm account dựa vào Email hoặc GoogleId
                var account = _context.Accounts.FirstOrDefault(a => a.Email == payload.Email || a.GoogleId == payload.Subject);

                if (account == null)
                {
                    // Nếu không có tài khoản thì tạo mới
                    account = new Account
                    {
                        Id = Guid.NewGuid().ToString(),
                        GoogleId = payload.Subject,
                        Email = payload.Email,
                        UserName = payload.Name,
                        ImageUrl = payload.Picture,
                        RoleId = "1" // Gán vai trò mặc định nếu cần
                    };

                    _context.Accounts.Add(account);
                    await _context.SaveChangesAsync();
                }

                // Tạo JWT Token
                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, account.Id),
                new Claim(JwtRegisteredClaimNames.Email, account.Email),
                new Claim("name", account.UserName),
                new Claim("role", account.RoleId)
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["JwtSettings:Issuer"],
                    audience: _configuration["JwtSettings:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        public class GoogleLoginRequest
        {
            public string Token { get; set; }
        }

        [AllowAnonymous]
        [Route("registration")]
        [HttpPost]
        public async Task<IActionResult> Registration(RegisterDTO account)
        {
            try
            {
                var a = await this.account.Registration(account);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDTO forgotPasswordRequest)
        {
            var result = await account.ForgotPasswordAsync(forgotPasswordRequest);
            if (!result)
            {
                return BadRequest("Failed to send reset password email.");
            }

            return Ok("Reset password email sent.");
        }
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordRequest)
        {
            try
            {
                Console.WriteLine($"Resetting password for email: {resetPasswordRequest.Email}");
                var result = await account.ResetPasswordAsync(resetPasswordRequest.Email, resetPasswordRequest.Token, resetPasswordRequest.NewPassword);
                if (!result)
                {

                    return BadRequest();
                }

                return Ok("Password reset successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Internal server error: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost("Enable-{accountId}")]
        public async Task<IActionResult> EnableAccount(string accountId)
        {
            try
            {
                var account = await this.account.GetById(accountId);
                if (account == null)
                {
                    return NotFound(new { message = $"Account with Id {accountId} not found." });
                }

                if (account.IsActive == true)
                {
                    return BadRequest(new { message = $"Account with Id {accountId} is already enabled." });
                }

                await this.account.EnableAccount(accountId);
                return Ok(new { message = $"Account with Id {accountId} has been enabled." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error enabling Account with Id {accountId}: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("Delete-{accountId}")]
        public async Task<IActionResult> DeleteAccount(string accountId)
        {
            try
            {
                var account = await this.account.GetById(accountId);
                if (account == null)
                {
                    return NotFound(new { message = $"Account with Id {accountId} not found." });
                }

                if (account.IsActive == false)
                {
                    return BadRequest(new { message = $"Account with Id {accountId} is already delete." });
                }

                await this.account.DeleteAccount(accountId);
                return Ok(new { message = $"Account with Id {accountId} has been deleted." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error delete Account with Id {accountId}: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpGet("Get-All")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var account = await this.account.GetAll();

                if (account == null)
                {
                    return NotFound(new { message = "No account found." });
                }

                return Ok(account);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving account: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("Update-Account")]
        public async Task<IActionResult> UpdateAccount(EditAccountDTO edit)
        {
            try
            {
                var account = await this.account.EditAccount(edit);

                if (account == null)
                {
                    return NotFound(new { message = "cannot edit account." });
                }

                return Ok(account);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving account: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("Update-Avatar-Account")]
        public async Task<IActionResult> UpdateImageAccount(IFormFile NewAva, string accountId)
        {
            try
            {
                  await this.account.UpdateImageAccount(NewAva, accountId);

                return Ok("Successfully updated poster");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving account: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(string accountId)
        {
            try
            {
                var account = await this.account.GetById(accountId);

                if (account == null)
                {
                    return NotFound(new { message = $"Account with Id: {accountId} not found." });
                }

                return Ok(account);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving account with Id {accountId}: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [Route("log-in")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO account)
        {
            try
            {
                var a = await this.account.Login(account);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
