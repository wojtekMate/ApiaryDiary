﻿using ApiaryDiary.Core.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiaryDiary.Application.Users.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private static IList<RefreshToken> _tokens = new List<RefreshToken>()
        {

        };

        public async Task AddAsync(RefreshToken token)
        {
            _tokens.Add(token);
            await Task.CompletedTask;
        }
        public async Task<RefreshToken> GetAsync(string token)
        => await Task.FromResult(_tokens.SingleOrDefault(x => x.Token == token));

        public async Task UpdateAsync(RefreshToken token)
        {
            var refreshToken = _tokens.SingleOrDefault(x => x.Id == token.Id);
            refreshToken = token;
            await Task.CompletedTask;
        }
        public async Task DeleteAsync(RefreshToken token)
            => await Task.FromResult(_tokens.Remove(_tokens.SingleOrDefault(x => x.Id == token.Id)));

        public async Task DeleteAsync(Guid userId)
        {
            var tokensToDelete = _tokens.Where(x => x.UserId == userId).ToList();
            foreach (var token in tokensToDelete)
            {
                _tokens.Remove(token);
            }
            await Task.CompletedTask;
        }
    }
}
