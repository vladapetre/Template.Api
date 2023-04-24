using Template.Domain.Models.Example;

namespace Template.Application.Example.Queries;

public sealed class GetExamplesQueryResponse
{
    private readonly IList<ExampleAggregateRoot> _examples;

    public GetExamplesQueryResponse(IList<ExampleAggregateRoot> examples)
    {
        _examples = examples;
    }

    public IReadOnlyCollection<ExampleAggregateRoot> Examples => _examples.AsReadOnly();
}
