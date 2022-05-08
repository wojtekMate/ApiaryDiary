using ApiaryDiary.Shared.Abstractions.Auth;

namespace ApiaryDiary.Modules.Users.Core.Services
{
    public interface IRefreshTokenService
    {
        Task<string> CreateAsync(Guid userId);
        Task RevokeAsync(string refreshToken);
        Task<JsonWebToken> UseAsync(string refreshToken);
    }
}
