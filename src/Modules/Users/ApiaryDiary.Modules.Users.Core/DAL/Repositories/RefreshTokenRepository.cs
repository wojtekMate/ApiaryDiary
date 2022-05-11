using ApiaryDiary.Modules.Users.Core.Entities;
using ApiaryDiary.Modules.Users.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiaryDiary.Modules.Users.Core.DAL.Repositories
{
    internal class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly RefreshTokensDbContext _context;
        private readonly DbSet<RefreshToken> _refreshTokens;

        public RefreshTokenRepository(RefreshTokensDbContext context)
        {
            _context = context;
            _refreshTokens = _context.RefreshTokens;
        }

        public async Task<RefreshToken> GetAsync(string token) => await _refreshTokens.SingleOrDefaultAsync(x => x.Token == token);

        public async Task AddAsync(RefreshToken token)
        {
            await _refreshTokens.AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RefreshToken token)
        {
            _refreshTokens.Update(token);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RefreshToken token)
        {
            _refreshTokens.Remove(token);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid userId)
        {
            var token =  await _refreshTokens.SingleOrDefaultAsync(x => x.UserId == userId);
            if (token is not null)
            {
                _refreshTokens.Remove(token);
            }
            await _context.SaveChangesAsync();
        }
    }
}
