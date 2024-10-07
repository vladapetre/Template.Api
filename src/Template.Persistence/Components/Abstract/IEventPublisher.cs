using Template.Core.Primitives;

namespace Template.Persistence.Components.Abstract;
public interface IEventPublisher
{
    public Task PublishAsync( Event @event );
}
