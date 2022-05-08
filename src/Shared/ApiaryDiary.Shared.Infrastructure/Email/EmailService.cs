using ApiaryDiary.Shared.Abstractions.Email;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace ApiaryDiary.Shared.Infrastructure.Email;


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
        await smtp.ConnectAsync(_options.Host, _options.Port, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_options.Account, _options.Password);
        await smtp.SendAsync(message);
        await smtp.DisconnectAsync(true);
    }
}