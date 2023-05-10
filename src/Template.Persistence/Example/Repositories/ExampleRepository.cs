using Microsoft.EntityFrameworkCore;
using Template.Domain.Models.Example;
using Template.Domain.Models.Example.Repositories;
using Template.Domain.Models.Example.Views;
using Template.Domain.Primitives;
using Template.Persistence.Contexts.Template;

namespace Template.Persistence.Example.Repositories;

internal class ExampleRepository : IExampleRepository
{
    private readonly TemplateContext _context;

    public ExampleRepository(TemplateContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task<IList<ExampleAggregateRoot>> GetAllAsync()
    {

        var example = ExampleAggregateRoot.CreateTemplate("Test", $"{DateTime.UtcNow.Millisecond % 100}");

        await _context.Example.AddAsync(example);
        await _context.SaveChangesAsync();

        return await _context.Example.ToListAsync();
    }

    public async Task<IList<ExampleView>> ProjectAllToSimpleViewsAsync()
    {
        return await _context.Example.AsNoTracking()
            .Select(example => new ExampleView(example.Status.Name, example.Description.Name, example.Description.Version))
            .ToListAsync();
    }
}
