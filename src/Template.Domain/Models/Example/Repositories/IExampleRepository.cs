using Template.Domain.Models.Example.Views;
using Template.Domain.Primitives;

namespace Template.Domain.Models.Example.Repositories;

public interface IExampleRepository : IRepository<ExampleAggregateRoot>
{
    Task<IList<ExampleAggregateRoot>> GetAllAsync();

    Task<IList<ExampleView>> ProjectAllToSimpleViewsAsync();
}
