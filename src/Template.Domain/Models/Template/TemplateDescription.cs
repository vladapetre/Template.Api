using Template.Domain.Primitives;

namespace Template.Domain.Models.Template;

public record TemplateDescription(string Name, string Version) : IValueObject { }
