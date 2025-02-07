using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;
using MailKit.Security;

namespace Booking_Dance_Bussiness

{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(MailboxAddress.Parse("Ducvldse172482@fpt.edu.vn"));
            emailMessage.To.Add(new MailboxAddress("", toEmail));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("html") { Text = message };

            using var client = new SmtpClient();
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("Ducvldse172482@fpt.edu.vn", "umnv fgro blxu ojvd");
                client.Send(emailMessage);
                client.Disconnect(true);


            }
        }
    }
}
