using ApiaryDiary.Modules.Users.Core.Entities;
using ApiaryDiary.Modules.Users.Core.Repositories;
using ApiaryDiary.Modules.Users.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ApiaryDiary.Modules.Users.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
            => services
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IRefreshTokenRepository, RefreshTokenRepository>()
                .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<IRefreshTokenService, RefreshTokenService>()
                .AddTransient<IRng, Rng>()
                .AddTransient<IUserEmailService, UserEmailService>();
        
                
    }
}
