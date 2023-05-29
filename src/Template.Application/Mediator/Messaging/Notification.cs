using MediatR;
using Template.Domain.Primitives;

namespace Template.Application.Mediator.Messaging;
public sealed class Notification<T> : INotification
{
    public Notification(T payload)
    {
        Payload = payload;
    }

    public T Payload { get; init; } = default!;

    public static object Create<TEvent>(TEvent @event) where TEvent : IEvent
    {
        var eventType = @event.GetType();
        var notificationType = typeof(Notification<>).MakeGenericType(eventType);
        var notification = Activator.CreateInstance(notificationType, @event);

        return notification;
    }
}
