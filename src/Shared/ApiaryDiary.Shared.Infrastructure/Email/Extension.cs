using ApiaryDiary.Shared.Abstractions.Email;
using Microsoft.Extensions.DependencyInjection;

namespace ApiaryDiary.Shared.Infrastructure.Email;

public static class Extension
{
    public static IServiceCollection AddEmailService(this IServiceCollection services)
    {
        var options = services.GetOptions<EmailServiceOptions>("mailService");
        services.AddSingleton(options);
        services.AddScoped<IEmailService, EmailService>();
        return services;
    }
}