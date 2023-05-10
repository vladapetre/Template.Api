using Template.Domain.Primitives;

namespace Template.Domain.Models.Example.Events;
public sealed class ExampleCreatedEvent : IEvent
{
    public int ExampleId { get; init; }
    public ExampleStatus Status { get; init; }
    public ExampleCreatedEvent(int exampleId, ExampleStatus status)
    {
        ExampleId = exampleId;
        Status = status;
    }
}
