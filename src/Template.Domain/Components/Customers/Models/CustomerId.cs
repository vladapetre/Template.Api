using System.Text.Json.Serialization;
using Template.Core.Primitives;

namespace Template.Domain.Components.Customers.Models;

public record class CustomerId : ValueObject
{
    public Guid Id { get; private init; }

    [JsonConstructor]
    private CustomerId( Guid id ) => Id = id;

    public static CustomerId Create() => new(Guid.CreateVersion7());
    public static CustomerId Create( Guid guid ) => new(guid);
}
