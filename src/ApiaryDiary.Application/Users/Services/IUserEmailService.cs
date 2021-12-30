using ApiaryDiary.Core.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiaryDiary.Application.Users.Services
{
    public interface IUserEmailService
    {
        Task SendActivationEmail(User user);
    }
}
