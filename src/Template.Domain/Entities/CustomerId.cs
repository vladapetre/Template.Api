
namespace Template.Domain.Entities;

public record class CustomerId
{
    public Guid Id { get; private init; }

    private CustomerId(Guid id) => (Id) = (id);

    public static CustomerId Create() => new(Guid.CreateVersion7());
}
