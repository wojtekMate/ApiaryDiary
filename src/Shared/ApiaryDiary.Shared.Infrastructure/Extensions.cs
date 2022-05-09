using System.Reflection;
using ApiaryDiary.Shared.Abstractions.Modules;
using ApiaryDiary.Shared.Abstractions.Time;
using ApiaryDiary.Shared.Infrastructure.Auth;
using ApiaryDiary.Shared.Infrastructure.Contexts;
using ApiaryDiary.Shared.Infrastructure.Email;
using ApiaryDiary.Shared.Infrastructure.Time;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiaryDiary.Shared.Infrastructure;

public static class Extensions
{
    private const string CorsPolicy = "cors";

    public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services,IList<Assembly> assemblies, IList<IModule> modules)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicy,
                builder =>
                {
                    builder.WithOrigins("*")
                        .WithMethods("POST", "PUT", "DELETE")
                        .WithHeaders("Content-Type", "Authorization");
                    //                    .WithOrigins("*")
                    //.AllowAnyHeader()
                    //.AllowAnyMethod();
                    //.WithOrigins("http://localhost:4200")
                    //    .AllowAnyHeader()
                    //    .AllowAnyMethod();
                });
        });
        services.AddSingleton<IContextFactory, ContextFactory>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient(sp => sp.GetRequiredService<IContextFactory>().Create());
        services.AddAuth(modules);
        services.AddSingleton<IClock, UtcClock>();
        services.AddEmailService();
        services.AddControllers();
        return services;
    }

    public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
    {
        using var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        return configuration.GetOptions<T>(sectionName);
    }

    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : new()
    {
        var options = new T();
        configuration.GetSection(sectionName).Bind(options);
        return options;
    }

    public static IApplicationBuilder UseSharedInfrastructure(this IApplicationBuilder app)
    {
        app.UseCors(CorsPolicy);
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();

        return app;
    }
}