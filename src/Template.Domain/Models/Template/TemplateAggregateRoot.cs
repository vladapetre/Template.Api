using Template.Domain.Primitives;

namespace Template.Domain.Models.Template;

public sealed class TemplateAggregateRoot : IEntity, IAggregateRoot
{
    public TemplateDescription Description { get; private set; }

    public TemplateStatus Status { get; private set; }

    private TemplateAggregateRoot(TemplateStatus status, TemplateDescription description) 
    {
        Status = status;
        Description = description;
    }

    public static TemplateAggregateRoot CreateTemplate(string name, string version) => new(TemplateStatus.Draft, new TemplateDescription(name, version));
       
    public void MarkAsCompleted()
    {
        Status = TemplateStatus.Completed;
    }
}
