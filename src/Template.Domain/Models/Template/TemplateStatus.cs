using Template.Domain.Exceptions;
using Template.Domain.Primitives;

namespace Template.Domain.Models.Template;

public class TemplateStatus : IEnumeration
{

    public static readonly TemplateStatus Draft = new(1, nameof(Draft).ToLowerInvariant());
    public static readonly TemplateStatus Completed = new(2, nameof(Completed).ToLowerInvariant());

    public TemplateStatus(int id, string name) : base(id, name)
    {
    }


    public static IEnumerable<TemplateStatus> List() =>
        new[] { Draft, Completed };


    public static TemplateStatus FromName(string name)
    {
        var state = List()
            .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

        if (state == null)
        {
            throw new TemplateDomainException($"Possible values for TemplateType: {String.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }

    public static TemplateStatus From(int id)
    {
        var state = List().SingleOrDefault(s => s.Id == id);

        if (state == null)
        {
            throw new TemplateDomainException($"Possible values for TemplateType: {String.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }
}
