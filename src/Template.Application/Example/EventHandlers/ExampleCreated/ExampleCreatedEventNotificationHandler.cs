using Template.Application.Mediator.Messages;
using Template.Application.Mediator.Messages.Events;
using Template.Application.Mediator.Messages.Notifications.Publishers;
using Template.Application.Mediator.Messages.Notifications;
using Template.Domain.Models.Example.Events;

namespace Template.Application.Example.EventHandlers.ExampleCreated;
internal class ExampleCreatedEventNotificationHandler : IApplicationEventHandler<ExampleCreatedEvent>
{
    private readonly IApplicationNotificationPublisher _notificationPublisher;

    public ExampleCreatedEventNotificationHandler(IApplicationNotificationPublisher notificationPublisher)
    {
        _notificationPublisher = notificationPublisher;
    }

    public async Task Handle(IApplicationEvent<ExampleCreatedEvent> @event, CancellationToken cancellationToken)
    {
        await _notificationPublisher.PublishAsync(new ApplicationNotification<ExampleCreatedEvent>(@event.Payload));
    }
}
