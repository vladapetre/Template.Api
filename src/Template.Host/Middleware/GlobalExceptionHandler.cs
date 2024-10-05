using Microsoft.AspNetCore.Diagnostics;

namespace Template.Host.Middleware;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> logger;

    public GlobalExceptionHandler( ILogger<GlobalExceptionHandler> logger )
    {
        this.logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync( HttpContext httpContext, Exception exception, CancellationToken cancellationToken )
    {
        logger.LogError(exception, "Unexpected exception occurred: {Message}", exception.Message);

        await Results.Problem(
                title: "Unexpected Server Error",
                statusCode: StatusCodes.Status500InternalServerError,
                detail: exception.Message,
                type: "https://datatracker.ietf.org/doc/html/rfc723#section-6.6.1",
                extensions: null)
            .ExecuteAsync(httpContext);

        return true;
    }


}
