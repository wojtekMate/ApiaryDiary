using ApiaryDiary.Core.Users.Entities;
using MimeKit;
using MimeKit.Text;
using Shared.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiaryDiary.Application.Users.Services
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
