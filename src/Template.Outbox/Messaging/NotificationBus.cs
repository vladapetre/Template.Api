using MassTransit;
using MassTransit.EntityFrameworkCoreIntegration;
using MassTransit.Transports;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Template.Application.Mediator.Messaging.Notifications;
using Template.Domain.Primitives;
using Template.Outbox.Contexts.Outbox;

namespace Template.Outbox.Messaging;

internal sealed class NotificationBus : INotificationBus
{
    private readonly OutboxContext _outboxContext;
    private readonly IPublishEndpoint _publishEndpoint;

    public NotificationBus(OutboxContext outboxContext, IPublishEndpoint publishEndpoint)
    {
        _outboxContext = outboxContext;
        _publishEndpoint = publishEndpoint;
    }

    public async Task PublishAsync<TEvent>(Notification<TEvent> notification) where TEvent : IEvent
    {
        try
        {
            await _publishEndpoint.Publish(notification.Payload);
            await _outboxContext.SaveChangesAsync();
        }
        catch (DbUpdateException exception) when (exception.InnerException is SqlException { Number: 2601 }) // Violation of unique key
        {
            throw new Exception("Duplicate key registration", exception);
        }
        catch (DbUpdateException exception) when (exception.InnerException is SqlException { Number: 2627 }) // Violation of unique constraint
        {
            throw new Exception("Duplicate constraint registration", exception);
        }
    }
}
