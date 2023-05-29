using Microsoft.Extensions.Logging;
using Polly;

namespace Template.Infrastructure.Http.Client.Handlers;
internal sealed class HttpClientCircuitBreakerHandler : DelegatingHandler
{
    private readonly ILogger<HttpClientCircuitBreakerHandler> _logger;

    public HttpClientCircuitBreakerHandler(ILogger<HttpClientCircuitBreakerHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var policy = Policy
            .HandleResult<HttpResponseMessage>(response => !response.IsSuccessStatusCode)
            .AdvancedCircuitBreakerAsync(
                failureThreshold: 1,
                samplingDuration: TimeSpan.FromMinutes(1),
                minimumThroughput: 3,
                durationOfBreak: TimeSpan.FromMinutes(1),
                onBreak: (response, time, context) =>
                {
                    _logger.LogWarning("{@OperationKey}: Circuit cut.", context.OperationKey);
                },
                onReset: (context) =>
                {
                    _logger.LogWarning("{@OperationKey}: Circuit reset.", context.OperationKey);
                }
            );

        return await policy.ExecuteAsync(async ctx => await base.SendAsync(request, cancellationToken), new Context($"{request.RequestUri}"));
    }
}
