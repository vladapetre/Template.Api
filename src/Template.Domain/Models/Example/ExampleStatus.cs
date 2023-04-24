using Template.Domain.Exceptions;
using Template.Domain.Primitives;

namespace Template.Domain.Models.Example;

public class ExampleStatus : IEnumeration
{

    public static readonly ExampleStatus Draft = new(1, nameof(Draft).ToLowerInvariant());
    public static readonly ExampleStatus Completed = new(2, nameof(Completed).ToLowerInvariant());

    public ExampleStatus(int id, string name) : base(id, name)
    {
    }


    public static IEnumerable<ExampleStatus> List() =>
        new[] { Draft, Completed };


    public static ExampleStatus FromName(string name)
    {
        var state = List()
            .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

        if (state == null)
        {
            throw new DomainException($"Possible values for TemplateType: {string.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }

    public static ExampleStatus From(int id)
    {
        var state = List().SingleOrDefault(s => s.Id == id);

        if (state == null)
        {
            throw new DomainException($"Possible values for TemplateType: {string.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }
}
