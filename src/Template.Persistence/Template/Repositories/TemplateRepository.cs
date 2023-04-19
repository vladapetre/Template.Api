using Microsoft.EntityFrameworkCore;
using Template.Domain.Models.Template;
using Template.Domain.Models.Template.Repositories;
using Template.Domain.Models.Template.Views;
using Template.Domain.Primitives;
using Template.Persistence.Contexts.Template;

namespace Template.Persistence.Template.Repositories;

internal class TemplateRepository : ITemplateRepository
{
    private readonly TemplateContext _context;

    public TemplateRepository(TemplateContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task<IList<TemplateAggregateRoot>> GetAllAsync()
    {
        return await _context.Template.ToListAsync();
    }

    public async Task<IList<TemplateSimpleView>> ProjectAllToSimpleViewsAsync()
    {
        return await _context.Template.AsNoTracking()
            .Select(template => new TemplateSimpleView(template.Status.Name, template.Description.Name, template.Description.Version))
            .ToListAsync();
    }
}
