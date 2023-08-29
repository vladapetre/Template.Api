using MediatR;
using Template.Domain.Primitives;

namespace Template.Application.Mediator.Messages.Events;
public sealed class ApplicationEvent<TEvent> : IApplicationEvent<TEvent> where TEvent : IEvent
{
    public ApplicationEvent(TEvent payload)
    {
        Payload = payload;
    }

    public TEvent Payload { get; init; } = default!;
}
