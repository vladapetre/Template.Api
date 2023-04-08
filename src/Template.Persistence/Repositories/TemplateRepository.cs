using Microsoft.EntityFrameworkCore;
using Template.Domain.Models.Template;
using Template.Domain.Models.Template.Repositories;
using Template.Domain.Primitives;
using Template.Persistence.Contexts;

namespace Template.Persistence.Repositories;

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
}
