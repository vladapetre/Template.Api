using MediatR;
using Template.Domain.Primitives;

namespace Template.Application.Mediator.Messaging;
internal sealed class EventBus : IEventBus
{
    private readonly IMediator _mediator;

    public EventBus(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
    {
        await _mediator.Publish(Notification<TEvent>.Create(@event));
    }
}
