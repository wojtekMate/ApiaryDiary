using ApiaryDiary.Modules.Users.Core.DTO;
using ApiaryDiary.Shared.Abstractions.Auth;

namespace ApiaryDiary.Modules.Users.Core.Services
{
    public interface IIdentityService
    {
        Task<AccountDto> GetAsync(Guid id);
        Task<JsonWebToken> SignInAsync(SignInDto dto);
        Task SignUpAsync(SignUpDto dto);
        Task ActivateUser(ActivateAccaountDto dto);
    }
}