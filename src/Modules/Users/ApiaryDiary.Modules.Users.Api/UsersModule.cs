using ApiaryDiary.Modules.Users.Core;
using ApiaryDiary.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ApiaryDiary.Modules.Users.Api;

public class UsersModule : IModule
{
    public const string BasePath = "users-module";
    public string Name { get; } = "Users";
    public string Path => BasePath;

    public IEnumerable<string> Policies { get; } = new[]
    {
        "users"
    };
    public void Register(IServiceCollection services)
    {
        services.AddCore();
    }

    public void Use(IApplicationBuilder app)
    {

    }
}