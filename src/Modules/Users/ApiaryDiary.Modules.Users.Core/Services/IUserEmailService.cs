using ApiaryDiary.Modules.Users.Core.Entities;

namespace ApiaryDiary.Modules.Users.Core.Services
{
    public interface IUserEmailService
    {
        Task SendActivationEmail(User user);
    }
}
