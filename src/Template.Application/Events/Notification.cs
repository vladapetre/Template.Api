using MediatR;
using Template.Domain.Primitives;

namespace Template.Application.Events;
internal sealed class Notification<TEvent> : INotification where TEvent : IEvent
{
    public Notification(TEvent @event)
    {
        Event = @event;
    }

    public TEvent Event { get; init; }
}
