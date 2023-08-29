using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Template.Infrastructure.Http.Correlation;

namespace Template.Host.Middleware;

public class CorrelationMiddleware
{
    private readonly RequestDelegate _next;
    private const string CORRELATION_ID_HEADER = "X-Correlation-Id";

    public CorrelationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, ICorrelationService correlationService)
    {
        var correlationId = GetCorrelationId(context, correlationService);
        AddCorrelationIdHeaderToResponse(context, correlationId);
        await _next(context);
    }

    private static StringValues GetCorrelationId(HttpContext context, ICorrelationService correlationService)
    {
        if (context.Request.Headers.TryGetValue(CORRELATION_ID_HEADER, out var correlationId) && correlationId != string.Empty)
        {
            correlationService.SetCorrelationId(correlationId!);
            return correlationId;
        }
        else
        {
            return correlationService.GetCorrelationId();
        }
    }

    private static void AddCorrelationIdHeaderToResponse(HttpContext context, StringValues correlationId)
    {
        context.Response.OnStarting(() =>
        {
            context.Response.Headers.Add(CORRELATION_ID_HEADER, new[] { correlationId.ToString() });
            return Task.CompletedTask;
        });
    }
}
