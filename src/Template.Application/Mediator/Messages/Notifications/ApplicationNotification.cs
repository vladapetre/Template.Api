using MediatR;
using Template.Domain.Primitives;

namespace Template.Application.Mediator.Messages.Notifications;
public sealed class ApplicationNotification<TEvent> : IApplicationNotification<TEvent> where TEvent : IEvent
{
    public ApplicationNotification(TEvent payload)
    {
        Payload = payload;
    }

    public TEvent Payload { get; init; } = default!;
}
