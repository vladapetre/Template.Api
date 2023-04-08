using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Primitives;

namespace Template.Domain.Models.Template.Repositories;

public interface ITemplateRepository : IRepository<TemplateAggregateRoot>
{
    Task<IList<TemplateAggregateRoot>> GetAllAsync();
}
