using Template.Domain.Models.Template.Views;
using Template.Domain.Primitives;

namespace Template.Domain.Models.Template.Repositories;

public interface ITemplateRepository : IRepository<TemplateAggregateRoot>
{
    Task<IList<TemplateAggregateRoot>> GetAllAsync();

    Task<IList<TemplateSimpleView>> ProjectAllToSimpleViewsAsync();
}
