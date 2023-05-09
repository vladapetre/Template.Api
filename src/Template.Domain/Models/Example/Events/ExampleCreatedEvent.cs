using Template.Domain.Primitives;

namespace Template.Domain.Models.Example.Events;
public record ExampleCreatedEvent(int ExampleId, ExampleStatus Status) : IEvent;
