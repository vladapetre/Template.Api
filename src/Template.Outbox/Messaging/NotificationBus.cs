using Microsoft.Extensions.Logging;
using Template.Application.Mediator.Messaging;
using Template.Domain.Primitives;
using Template.Outbox.Contexts.Outbox;
using Template.Outbox.Models;

namespace Template.Outbox.Messaging;

internal sealed class NotificationBus : INotificationBus
{
    private readonly OutboxContext _outboxContext;

    public NotificationBus(OutboxContext outboxContext)
    {
        _outboxContext = outboxContext;
    }

    public async Task PublishAsync<TEvent>(Notification<TEvent> notification) where TEvent : IEvent
    {
        var message = new OutboxMessage(notification);

        await _outboxContext.OutboxMessage.AddAsync(message);
        await _outboxContext.SaveChangesAsync();
    }
}
