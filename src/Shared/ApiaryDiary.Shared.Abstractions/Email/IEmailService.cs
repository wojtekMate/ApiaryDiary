using MimeKit;

namespace ApiaryDiary.Shared.Abstractions.Email;

public interface IEmailService
{
    Task SendEmailAsync(MimeMessage message);
}