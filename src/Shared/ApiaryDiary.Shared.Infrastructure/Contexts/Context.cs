using ApiaryDiary.Shared.Abstractions.Contexts;
using Microsoft.AspNetCore.Http;

namespace ApiaryDiary.Shared.Infrastructure.Contexts;

internal class Context : IContext
{
    internal Context()
    {
    }

    public Context(HttpContext context) : this(context.TraceIdentifier, new IdentityContext(context.User))
    {
    }

    internal Context(string traceId, IIdentityContext identity)
    {
        TraceId = traceId;
        Identity = identity;
    }

    public static IContext Empty => new Context();
    public string RequestId { get; } = $"{Guid.NewGuid():N}";
    public string TraceId { get; }
    public IIdentityContext Identity { get; }
}