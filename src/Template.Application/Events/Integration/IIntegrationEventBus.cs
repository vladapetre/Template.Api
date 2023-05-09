namespace Template.Application.Events.Integration;
public interface IIntegrationEventBus
{
    Task DispatchAsync<TIntegrationEvent>(TIntegrationEvent @event) where TIntegrationEvent : IIntegrationEvent;
}
