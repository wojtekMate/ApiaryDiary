using ApiaryDiary.Application.Users.Repositories;
using ApiaryDiary.Application.Users.Services;
using ApiaryDiary.Core.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiaryDiary.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
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
