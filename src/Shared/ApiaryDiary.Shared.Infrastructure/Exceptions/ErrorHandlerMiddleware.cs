using System.Net;
using ApiaryDiary.Shared.Abstractions.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ApiaryDiary.Shared.Infrastructure.Exceptions;

public class ErrorHandlerMiddleware : IMiddleware
{
    private readonly IExceptionToResponseMapper _mapper;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(IExceptionToResponseMapper mapper,ILogger<ErrorHandlerMiddleware> logger)
    {
        _mapper = mapper;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception,exception.Message);
            await HandleErrorAsync(exception, context);
        }
    }

    private async Task HandleErrorAsync(Exception exception, HttpContext context)
    {
        var errorResponse = _mapper.Map(exception);
        context.Response.StatusCode = (int)(errorResponse?.StatusCode ?? HttpStatusCode.InternalServerError);
        var response = errorResponse?.Response;
        if (response is null)
        {
            return;
        }
        await context.Response.WriteAsJsonAsync(response);

    }
}