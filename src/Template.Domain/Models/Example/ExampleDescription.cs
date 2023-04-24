using Template.Domain.Primitives;

namespace Template.Domain.Models.Example;

public record ExampleDescription(string Name, string Version) : IValueObject { }
