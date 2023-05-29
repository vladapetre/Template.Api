using Template.Domain.Models.Example;
using Template.Infrastructure.Mappers;

namespace Template.Infrastructure.Example.Mappers;
internal sealed class ExampleToObjectMapper : IMapper<ExampleAggregateRoot, object>
{
    public Task<object?> Map(ExampleAggregateRoot from)
    {
        return Task.FromResult((object?)from ?? default);
    }

    public Task<ExampleAggregateRoot?> Map(object to)
    {
        return Task.FromResult(to as ExampleAggregateRoot ?? default);
    }
}
