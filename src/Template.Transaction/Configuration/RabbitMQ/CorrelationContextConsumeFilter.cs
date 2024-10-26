using MassTransit;
using Template.Core.Contexts;
using Template.Core.Types;

namespace Template.Transaction.Configuration.RabbitMQ;

public class CorrelationContextConsumeFilter<TMessage> : IFilter<ConsumeContext<TMessage>>
    where TMessage : class
{
    private readonly CorrelationContext correlationContext;

    public CorrelationContextConsumeFilter(CorrelationContext correlationContext)
    {
        this.correlationContext = correlationContext;
    }

    public async Task Send( ConsumeContext<TMessage> context, IPipe<ConsumeContext<TMessage>> next )
    {
        if (context.CorrelationId is not null)
        {
            correlationContext.CorrelationId = CorrelationId.Create(context.CorrelationId.ToString());
        }

        await next.Send(context);
    }

    public void Probe( ProbeContext context )
    {
    }
}