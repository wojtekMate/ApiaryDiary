using ApiaryDiary.Modules.Users.Core.Entities;
using ApiaryDiary.Shared.Abstractions.Email;
using ApiaryDiary.Shared.Infrastructure.Email;
using MimeKit;
using MimeKit.Text;

namespace ApiaryDiary.Modules.Users.Core.Services
{
    internal class UserEmailService : IUserEmailService
    {
        
        private readonly IEmailService _emailService;
        private readonly EmailServiceOptions _options;

        public UserEmailService(IEmailService emailService, EmailServiceOptions options)
        {
            _emailService = emailService;
            _options = options;
        }

        public async Task SendActivationEmail(User user)
        {
            var token = user.UserActivationToken;
            var link = _options.ActivationLink + token;

            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse("apiary-diary.com"));
            message.To.Add(MailboxAddress.Parse(user.Email));
            message.Subject = "Apiary-diary.com activation link";
            string body = "Hello," + Environment.NewLine + "welcome to the Apiary Diary. Please click on the link below to activate your account:" + Environment.NewLine + link;
            message.Body = new TextPart(TextFormat.Plain) { Text = body };

            await _emailService.SendEmailAsync(message);
        }
        
    }
}
