namespace Template.Core.Primitives;

public abstract record class Entity
{
    private readonly ICollection<IEvent> events = [];
    public IReadOnlyCollection<IEvent> Events => events.ToList().AsReadOnly();
    protected void RaiseEvent( IEvent @event ) => events.Add(@event);
    public void ClearEvents() => events.Clear();
}
