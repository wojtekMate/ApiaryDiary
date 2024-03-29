﻿using System.Reflection;
using ApiaryDiary.Shared.Abstractions.Modules;
using ApiaryDiary.Shared.Abstractions.Time;
using ApiaryDiary.Shared.Infrastructure.Api;
using ApiaryDiary.Shared.Infrastructure.Auth;
using ApiaryDiary.Shared.Infrastructure.Contexts;
using ApiaryDiary.Shared.Infrastructure.Email;
using ApiaryDiary.Shared.Infrastructure.Exceptions;
using ApiaryDiary.Shared.Infrastructure.Postgres;
using ApiaryDiary.Shared.Infrastructure.Services;
using ApiaryDiary.Shared.Infrastructure.Time;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiaryDiary.Shared.Infrastructure;

public static class Extensions
{
    private const string CorsPolicy = "cors";

    public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services,IList<Assembly> assemblies, IList<IModule> modules)
    {
        var disabledModules = new List<string>();
        using (var serviceProvider = services.BuildServiceProvider())
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            foreach (var (key, value) in configuration.AsEnumerable())
            {
                if (!key.Contains(":module:enabled"))
                {
                    continue;
                }

                if (!bool.Parse(value))
                {
                    disabledModules.Add(key.Split(":")[0]);
                }
            }
        }
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
        services.AddControllers()
            .ConfigureApplicationPartManager(manager =>
            {
                var removedParts = new List<ApplicationPart>();
                foreach (var disabledModule in disabledModules)
                {
                    var parts = manager.ApplicationParts.Where(x => x.Name.Contains(disabledModule,
                        StringComparison.InvariantCultureIgnoreCase));
                    removedParts.AddRange(parts);
                }

                foreach (var part in removedParts)
                {
                    manager.ApplicationParts.Remove(part);
                }
                    
                manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
            });
        services.AddErrorHandling();
        services.AddPostgres();
        services.AddHostedService<AppInitializer>();
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
    =>
        app.UseCors(CorsPolicy)
                .UseAuthentication()
                .UseRouting()
                .UseAuthorization()
                .UseErrorHandling();
}