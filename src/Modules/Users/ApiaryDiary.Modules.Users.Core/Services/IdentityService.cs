using System.Security.Authentication;
using ApiaryDiary.Modules.Users.Core.DTO;
using ApiaryDiary.Modules.Users.Core.Entities;
using ApiaryDiary.Modules.Users.Core.Exceptions;
using ApiaryDiary.Modules.Users.Core.Repositories;
using ApiaryDiary.Shared.Abstractions.Auth;
using ApiaryDiary.Shared.Abstractions.Time;
using Microsoft.AspNetCore.Identity;

namespace ApiaryDiary.Modules.Users.Core.Services
{
    internal class IdentityService : IIdentityService
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IAuthManager _authManager;
        private readonly IClock _clock; 
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IUserEmailService _emailService;

        public IdentityService(IPasswordHasher<User> passwordHasher,IAuthManager authManager, IClock clock, IUserRepository userRepository, IRefreshTokenService refreshTokenService, IUserEmailService emailService)
        {
            _passwordHasher = passwordHasher;
            _authManager = authManager;
            _clock = clock;
            _userRepository = userRepository;
            _refreshTokenService = refreshTokenService;
            _emailService = emailService;
        }

        public async Task<AccountDto> GetAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);

            return user is null
                ? null
                : new AccountDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Role = user.Role,
                    Claims = user.Claims,
                    CreatedAt = user.CreatedAt
                };
        }

        public async Task<ApiaryDiary.Shared.Abstractions.Auth.JsonWebToken> SignInAsync(SignInDto dto)
        {
            var user = await _userRepository.GetAsync(dto.Email.ToLowerInvariant());
            if (user is null)
            {
                throw new InvalidCredentialException();
            }

            if (_passwordHasher.VerifyHashedPassword(default, user.Password, dto.Password) ==
                PasswordVerificationResult.Failed)
            {
                throw new InvalidCredentialException();
            }

            if (!user.IsActive)
            {
                throw new UserNotActiveException(user.Id);
            }
            var refreshToken = await _refreshTokenService.CreateAsync(user.Id);
            var jwt = _authManager.CreateToken(user.Id.ToString(), user.Role, claims: user.Claims);
            jwt.Email = user.Email;
            jwt.RefreshToken = refreshToken;

            return jwt;
        }

        public async Task SignUpAsync(SignUpDto dto)
        {
            dto.Id = Guid.NewGuid();
            var email = dto.Email.ToLowerInvariant();
            var user = await _userRepository.GetAsync(email);
            if (user is not null)
            {
                throw new EmailInUseException();
            }

            var password = _passwordHasher.HashPassword(default, dto.Password);
            user = new User
            {
                Id = dto.Id,
                Email = email,
                Password = password,
                Role = dto.Role?.ToLowerInvariant() ?? "user",
                CreatedAt = _clock.CurrentDate(),
                IsActive = false,
                Claims = dto.Claims ?? new Dictionary<string, IEnumerable<string>>(),
                UserActivationToken = Guid.NewGuid().ToString("N")
        };
            await _userRepository.AddAsync(user);
            await _emailService.SendActivationEmail(user);
        }

        public async Task ActivateUser(ActivateAccaountDto dto)
        {
            var user = await _userRepository.GetByGuidAsync(dto.Token);
            if (user is null)
            {
                throw new InvalidActivationTokenException(dto.Token);
            }

            user.IsActive = true;
            await _userRepository.UpdateAsync(user);
        }

        public async Task ResetPassword(SignUpDto dto)
        {
            await Task.CompletedTask;
        }
    }
}