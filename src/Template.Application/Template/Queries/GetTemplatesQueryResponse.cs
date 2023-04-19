using Template.Domain.Models.Template;

namespace Template.Application.Template.Queries;

public sealed class GetTemplatesQueryResponse
{
    private readonly IList<TemplateAggregateRoot> _templates;

    public GetTemplatesQueryResponse(IList<TemplateAggregateRoot> templates)
    {
        _templates = templates;
    }

    public IReadOnlyCollection<TemplateAggregateRoot> Templates => _templates.AsReadOnly();
}