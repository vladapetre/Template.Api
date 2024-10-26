using Template.Core.Contexts;
using Template.Core.Types;

namespace Template.Host.Middleware.Contexts;

public class CorrelationContextMiddleware
{
    private readonly RequestDelegate next;
    private const string CorrelationIdHeaderName = "X-Correlation-ID";

    public CorrelationContextMiddleware( RequestDelegate next )
    {
        this.next = next;
    }

    public async Task Invoke( HttpContext context, CorrelationContext correlationContext )
    {
        GetRequestCorrelationId(context, correlationContext);
        SetResponseCorrelationId(context, correlationContext);

        await next(context);
    }

    private static void GetRequestCorrelationId( HttpContext context, CorrelationContext correlationContext )
    {
        if (context.Request.Headers.TryGetValue(CorrelationIdHeaderName, out var correlationId))
        {
            correlationContext.CorrelationId = CorrelationId.Create(correlationId);
        }
    }

    private static void SetResponseCorrelationId( HttpContext context, CorrelationContext correlationContext )
    {
        context.Response.OnStarting(() =>
        {
            context.Response.Headers.Add(CorrelationIdHeaderName, new[] { correlationContext.CorrelationId.Id });
            return Task.CompletedTask;
        });
    }
}