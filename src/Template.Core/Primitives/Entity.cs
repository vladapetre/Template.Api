namespace Template.Core.Primitives;

public abstract record class Entity
{
    private readonly ICollection<Event> events = [];
    public IReadOnlyCollection<Event> Events => events.ToList().AsReadOnly();
    protected void RaiseEvent( Event @event ) => events.Add(@event);
    public void ClearEvents() => events.Clear();
}
