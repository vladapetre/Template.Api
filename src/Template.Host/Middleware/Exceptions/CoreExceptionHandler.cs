using Microsoft.AspNetCore.Diagnostics;
using Template.Core.Exceptions;

namespace Template.Host.Middleware;

public sealed class CoreExceptionHandler : IExceptionHandler
{
    private readonly ILogger<CoreExceptionHandler> logger;

    public CoreExceptionHandler( ILogger<CoreExceptionHandler> logger )
    {
        this.logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync( HttpContext httpContext, Exception exception, CancellationToken cancellationToken )
    {
        if (exception is not CoreException generalException)
        {
            return false;
        }

        logger.LogError(exception, "Core exception occurred: {Code} - {Message}", generalException.Code, generalException.Message);

        await Results.Problem(
                title: "Core Error",
                statusCode: generalException.Code,
                detail: generalException.Message,
                type: "https://datatracker.ietf.org/doc/html/rfc723#section-6.6.1",
                extensions: null)
            .ExecuteAsync(httpContext);

        return true;
    }


}
