using Template.Core.Primitives;

namespace Template.Persistence.Components.Abstract;

public interface IEventHandler
{
    Task HandleAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent: IEvent;
}