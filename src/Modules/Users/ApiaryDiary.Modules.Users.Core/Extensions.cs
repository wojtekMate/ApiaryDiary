using ApiaryDiary.Modules.Users.Core.Entities;
using ApiaryDiary.Modules.Users.Core.Repositories;
using ApiaryDiary.Modules.Users.Core.Services;
using ApiaryDiary.Shared.Infrastructure.Postgres;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApiaryDiary.Modules.Users.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
            => services
                .AddScoped<IUserRepository, InMemoryUserRepository>()
                .AddScoped<IRefreshTokenRepository, InMemoryRefreshTokenRepository>()
                .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<IRefreshTokenService, RefreshTokenService>()
                .AddTransient<IRng, Rng>()
                .AddTransient<IUserEmailService, UserEmailService>()
                .AddPostgres<DbContext>();



    }
}
