using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System.ComponentModel;

namespace Shared.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailServiceOptions _options;
        public EmailService(EmailServiceOptions options)
        {
            _options = options;
        }

        public async Task SendEmailAsync(MimeMessage message)
        {
            using var smtp = new SmtpClient();
            smtp.Connect(_options.Host, _options.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_options.Account, _options.Password);
            smtp.Send(message);
            smtp.Disconnect(true);
        }
    }
}
