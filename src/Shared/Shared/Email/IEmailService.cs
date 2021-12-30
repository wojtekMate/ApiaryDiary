using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(MimeMessage message);
    }
}
