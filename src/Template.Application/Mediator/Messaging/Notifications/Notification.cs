using MediatR;
using Template.Domain.Primitives;

namespace Template.Application.Mediator.Messaging.Notifications;
public sealed class Notification<TPayload> : INotification
{
    public Notification(TPayload payload)
    {
        Payload = payload;
    }

    public TPayload Payload { get; init; } = default!;
}
