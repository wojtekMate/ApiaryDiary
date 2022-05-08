using ApiaryDiary.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ApiaryDiary.Modules.PowerStation.Api;

public class PowerStationModule : IModule
{
    public const string BasePath = "power-station-module";
    public string Name { get; } = "PowerStation";
    public string Path => BasePath;

    public IEnumerable<string> Policies { get; } = new[]
    {
        "power-station"
    };
    
    public void Register(IServiceCollection services)
    {
        
    }

    public void Use(IApplicationBuilder app)
    {

    }
}