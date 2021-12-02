using ApiaryDiary.Core.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiaryDiary.Application.Users.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private IList<RefreshToken> _tokens = new List<RefreshToken>()
        {

        };

        public async Task AddAsync(RefreshToken token)
        {
            _tokens.Add(token);
            await Task.CompletedTask;
        }
        public async Task<RefreshToken> GetAsync(string token)
        => await Task.FromResult(_tokens.SingleOrDefault(x => x.Token == token));

        public Task UpdateAsync(RefreshToken token)
        {
            throw new NotImplementedException();
        }
    }
}
