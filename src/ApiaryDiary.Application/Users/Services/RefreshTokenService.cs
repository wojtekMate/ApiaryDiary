using ApiaryDiary.Application.Users.DTO;
using ApiaryDiary.Application.Users.Repositories;
using ApiaryDiary.Core.Users.Entities;
using Shared.Auth;
using Shared.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiaryDiary.Application.Users.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAuthManager _authManager;
        private readonly IRng _rng;
        private readonly AuthOptions _options;
        private readonly IClock _clock;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository,
            IUserRepository userRepository, IAuthManager authManager, IRng rng, AuthOptions options, IClock clock)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository = userRepository;
            _authManager = authManager;
            _rng = rng;
            _options = options;
            _clock = clock;
        }

        public async Task<string> CreateAsync(Guid userId)
        {
            var token = _rng.Generate(30, true);
            var now = _clock.CurrentDate();
            var expires = now.Add(_options.ExpiryRefreshToken);
            var refreshToken = new RefreshToken(Guid.NewGuid(), userId, token, DateTime.UtcNow, expires);
            await _refreshTokenRepository.DeleteAsync(userId);
            await _refreshTokenRepository.AddAsync(refreshToken);
            return token;
        } 

        public async Task RevokeAsync(string refreshToken)
        {
            var token = await _refreshTokenRepository.GetAsync(refreshToken);
            if (token is null)
            {
                throw new Exception();
            }

            token.Revoke(DateTime.UtcNow);
            await _refreshTokenRepository.UpdateAsync(token);
        }

        public async Task<JsonWebToken> UseAsync(string refreshToken)
        {
            var token = await _refreshTokenRepository.GetAsync(refreshToken);
            if (token is null)
            {
                throw new Exception();
            }

            if (token.Revoked)
            {
                throw new Exception();
            }

            var user = await _userRepository.GetAsync(token.UserId);
            if (user is null)
            {
                throw new Exception();
            }

            var newRefreshToken = await CreateAsync(user.Id);
            var auth = _authManager.CreateToken(token.UserId.ToString(), user.Role, claims: user.Claims);
            auth.RefreshToken = newRefreshToken;

            return auth;
        }
    }
}
