using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Primitives;

namespace Template.Domain.Models.Template;

public sealed class TemplateAggregateRoot : IEntity, IAggregateRoot
{
    public TemplateDescription? Description { get; private set; }

    public TemplateStatus? Status { get; private set; }

    private TemplateAggregateRoot()
    {
        
    }

    public static TemplateAggregateRoot CreateTemplate(string name, string version) =>
        new()
        {
            Status = TemplateStatus.Draft,
            Description = new TemplateDescription(name, version),
        };

    public void MarkAsCompleted()
    {
        Status = TemplateStatus.Completed;
    }
}
