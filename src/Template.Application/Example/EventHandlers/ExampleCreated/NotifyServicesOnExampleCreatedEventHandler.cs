using MediatR;
using Template.Application.Events;
using Template.Domain.Models.Example.Events;

namespace Template.Application.Example.EventHandlers.ExampleCreated;
internal class NotifyServicesOnExampleCreatedEventHandler : INotificationHandler<Notification<ExampleCreatedEvent>>
{
    public Task Handle(Notification<ExampleCreatedEvent> notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
        return Task.CompletedTask;
    }
}
