using MassTransit;
using Template.Core.Primitives;
using Template.Outbox.Context;
using Template.Persistence.Components.Abstract;
using Event = Template.Core.Primitives.Event;

namespace Template.Outbox.Components.Abstract;

public class OutboxEventHandler : IEventHandler
{
    private readonly IPublishEndpoint publishEndpoint;
    private readonly OutboxDbContext outboxDbContext;

    public OutboxEventHandler(IPublishEndpoint publishEndpoint, OutboxDbContext outboxDbContext)
    {
        this.publishEndpoint = publishEndpoint;
        this.outboxDbContext = outboxDbContext;
    }
    
    public async Task HandleAsync<TEvent>( TEvent @event, CancellationToken cancellationToken = default ) 
        where TEvent : IEvent
    {
        await publishEndpoint.Publish(@event as object, cancellationToken);
        //await outboxDbContext.SaveChangesAsync(cancellationToken);
    }
}