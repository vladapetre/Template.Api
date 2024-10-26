using MassTransit;
using Template.Core.Contexts;

namespace Template.Transaction.Configuration.RabbitMQ;

public class CorrelationContextPublishFilter<TMessage> : IFilter<PublishContext<TMessage>>
    where TMessage : class
{
    private readonly CorrelationContext correlationContext;

    public CorrelationContextPublishFilter(CorrelationContext correlationContext)
    {
        this.correlationContext = correlationContext;
    }
    
    public async Task Send( PublishContext<TMessage> context, IPipe<PublishContext<TMessage>> next )
    {
        context.CorrelationId = 
            Guid.TryParse(correlationContext.CorrelationId.Id, out var correlationId) 
                ? correlationId : Guid.CreateVersion7();

        await next.Send(context);
    }

    public void Probe( ProbeContext context )
    {
    }
}