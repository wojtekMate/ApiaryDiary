using ApiaryDiary.Shared.Abstractions.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ApiaryDiary.Shared.Infrastructure.Exceptions;

public static class Extensions
{
    public static IServiceCollection AddErrorHandling(this IServiceCollection services)
        => services
            .AddScoped<ErrorHandlerMiddleware>()
            .AddSingleton<IExceptionToResponseMapper, ExceptionToResponseMapper>();

    public static IApplicationBuilder UseErrorHandling(IApplicationBuilder app)
    => app
        .UseMiddleware<ErrorHandlerMiddleware>();
    
}