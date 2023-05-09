using Template.Application.Events.Integration;
using Template.Outbox.Contexts.Outbox;
using Template.Outbox.Models;

namespace Template.Outbox.Events;

internal sealed class IntegrationEventBus : IIntegrationEventBus
{
    private readonly OutboxContext _outboxContext;

    public IntegrationEventBus(OutboxContext outboxContext)
    {
        _outboxContext = outboxContext;
    }

    public async Task DispatchAsync<TIntegrationEvent>(TIntegrationEvent @event) where TIntegrationEvent : IIntegrationEvent
    {
        var message = new OutboxMessage(@event);

        await _outboxContext.OutboxMessage.AddAsync(message);
        await _outboxContext.SaveChangesAsync();
    }
}
