using MassTransit;
using Template.Core.Contexts;

namespace Template.Transaction.Configuration.RabbitMQ;

public class CorrelationContextSendFilter<TMessage>: IFilter<SendContext>
    where TMessage : class
{
    private readonly CorrelationContext correlationContext;

    public CorrelationContextSendFilter(CorrelationContext correlationContext)
    {
        this.correlationContext = correlationContext;
    }
    
    public async Task Send( SendContext context, IPipe<SendContext> next )
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