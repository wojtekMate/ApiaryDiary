namespace ApiaryDiary.Api;

public static class Extensions
{
    public static IApplicationBuilder UseMyExceptionHandler(this IApplicationBuilder builder)
        => builder.UseMiddleware(typeof(Middleware));
}