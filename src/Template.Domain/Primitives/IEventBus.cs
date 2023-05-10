namespace Template.Domain.Primitives;
public interface IEventBus
{
    Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;
}
