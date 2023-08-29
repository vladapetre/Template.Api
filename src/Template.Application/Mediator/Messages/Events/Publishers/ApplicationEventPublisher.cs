using MediatR;
using Template.Domain.Primitives;

namespace Template.Application.Mediator.Messages.Events.Publishers;
internal sealed class ApplicationEventPublisher : IEventPublisher
{
    private readonly IMediator _mediator;

    public ApplicationEventPublisher(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
    {
        await _mediator.Publish(new ApplicationEvent<TEvent>(@event));
    }
}
