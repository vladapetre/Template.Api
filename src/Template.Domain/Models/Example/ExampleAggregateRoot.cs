using Template.Domain.Primitives;

namespace Template.Domain.Models.Example;

public sealed class ExampleAggregateRoot : IEntity, IAggregateRoot
{
    public ExampleDescription Description { get; private set; } = default!;

    public ExampleStatus Status { get; private set; } = default!;

    private ExampleAggregateRoot() { }

    private ExampleAggregateRoot(ExampleStatus status, ExampleDescription description)
    {
        Status = status;
        Description = description;
    }

    public static ExampleAggregateRoot CreateTemplate(string name, string version) => new(ExampleStatus.Draft, new ExampleDescription(name, version));

    public void MarkAsCompleted()
    {
        Status = ExampleStatus.Completed;
    }
}
