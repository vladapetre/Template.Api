using MediatR;
using Template.Domain.Primitives;

namespace Template.Application.Events;
internal sealed class EventBus : IEventBus
{
    private readonly IMediator _mediator;

    public EventBus(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task DispatchAsync<TEvent>(TEvent @event) where TEvent : IEvent
    {
        await _mediator.Publish(new Notification<TEvent>(@event));
    }
}
