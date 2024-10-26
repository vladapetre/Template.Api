using MassTransit;
using Microsoft.Extensions.Logging;
using Template.Core.Contexts;

namespace Template.Transaction.Configuration.RabbitMQ;

internal sealed class LoggingScopeConsumeFilter<TMessage> : IFilter<ConsumeContext<TMessage>>
    where TMessage : class
{
    private readonly CorrelationContext correlationContext;
    private readonly ILogger<LoggingScopeConsumeFilter<TMessage>> logger;

    public LoggingScopeConsumeFilter(
        CorrelationContext correlationContext,
        ILogger<LoggingScopeConsumeFilter<TMessage>> logger)
    {
        this.correlationContext = correlationContext;
        this.logger = logger;
    }

    public void Probe(ProbeContext context)
    {
    }

    public async Task Send(ConsumeContext<TMessage> context, IPipe<ConsumeContext<TMessage>> next)
    {
        var logMessageParams = new Dictionary<string, object>()
        {
            ["CorrelationId"] = correlationContext.CorrelationId,
            ["ConsumerId"] = Guid.NewGuid()
        };

        using (logger.BeginScope(logMessageParams))
        {
            await next.Send(context);
        }
    }
}