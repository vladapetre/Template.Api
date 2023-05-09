namespace Template.Domain.Primitives;
public interface IEventBus
{
    Task DispatchAsync<TEvent>(TEvent @event) where TEvent : IEvent;
}
