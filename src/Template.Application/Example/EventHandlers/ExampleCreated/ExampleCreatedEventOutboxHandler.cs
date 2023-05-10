using MediatR;
using Microsoft.Extensions.Logging;
using Template.Application.Mediator.Messaging;
using Template.Domain.Models.Example.Events;

namespace Template.Application.Example.EventHandlers.ExampleCreated;
internal class ExampleCreatedEventOutboxHandler : INotificationHandler<Notification<ExampleCreatedEvent>>
{
    private readonly INotificationBus _notificationBus;

    public ExampleCreatedEventOutboxHandler(INotificationBus notificationBus)
    {
        _notificationBus = notificationBus;
    }

    public async Task Handle(Notification<ExampleCreatedEvent> notification, CancellationToken cancellationToken)
    {
        await _notificationBus.PublishAsync(notification);
    }
}
