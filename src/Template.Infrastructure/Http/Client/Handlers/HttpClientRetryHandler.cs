using Microsoft.Extensions.Logging;
using Polly;

namespace Template.Infrastructure.Http.Client.Handlers;
internal sealed class HttpClientRetryHandler : DelegatingHandler
{
    private readonly ILogger<HttpClientRetryHandler> _logger;

    public HttpClientRetryHandler(ILogger<HttpClientRetryHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var policy = Policy
            .HandleResult<HttpResponseMessage>(response => !response.IsSuccessStatusCode)
            .WaitAndRetryAsync(
               retryCount: 3,
               sleepDurationProvider: _ => TimeSpan.FromMilliseconds(100),
               onRetry: (response, timespan, retryNo, context) =>
               {
                   _logger.LogWarning("{@OperationKey} : Retry number {@RetryNo} within {@TotalElapsed} ms. StatusCode: {@StatusCode}", context.OperationKey, retryNo, timespan.TotalMilliseconds, response.Result.StatusCode);
               }
            );

        return await policy.ExecuteAsync(async ctx => await base.SendAsync(request, cancellationToken), new Context($"{request.RequestUri}"));
    }
}
