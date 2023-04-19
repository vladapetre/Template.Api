using Template.Domain.Models.Template;

namespace Template.Infrastructure.Template.Mappers;
internal sealed class TemplateToObjectMapper : ITemplateMapper<TemplateAggregateRoot, object>
{
    public Task<object?> Map(TemplateAggregateRoot from)
    {
        return Task.FromResult((object?)from ?? default);
    }

    public Task<TemplateAggregateRoot?> Map(object to)
    {
        return Task.FromResult(to as TemplateAggregateRoot ?? default);
    }
}
