using ApiaryDiary.Modules.Users.Core.Entities;

namespace ApiaryDiary.Modules.Users.Core.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetAsync(string token);
        Task AddAsync(RefreshToken token);
        Task UpdateAsync(RefreshToken token);
        Task DeleteAsync(RefreshToken token);
        Task DeleteAsync(Guid userId);
    }
}
