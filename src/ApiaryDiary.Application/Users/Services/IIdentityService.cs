using System;
using System.Threading.Tasks;
using ApiaryDiary.Application.Users.DTO;
using Shared.Auth;

namespace ApiaryDiary.Application.Users.Services
{
    public interface IIdentityService
    {
        Task<AccountDto> GetAsync(Guid id);
        Task<JsonWebToken> SignInAsync(SignInDto dto);
        Task SignUpAsync(SignUpDto dto);
        Task ActivateUser(ActivateAccaountDto dto);
    }
}