using Template.Domain.Abstractions;

namespace Template.Domain.Components.Weather;
public sealed class WeatherSummary : IEnumeration
{
    public static readonly WeatherSummary Freezing = new(1, nameof(Freezing));
    public static readonly WeatherSummary Bracing = new(2, nameof(Bracing));
    public static readonly WeatherSummary Chilly = new(3, nameof(Chilly));
    public static readonly WeatherSummary Cool = new(4, nameof(Cool));
    public static readonly WeatherSummary Mild = new(5, nameof(Mild));
    public static readonly WeatherSummary Warm = new(6, nameof(Warm));
    public static readonly WeatherSummary Balmy = new(7, nameof(Balmy));
    public static readonly WeatherSummary Hot = new(8, nameof(Hot));
    public static readonly WeatherSummary Sweltering = new(9, nameof(Sweltering));
    public static readonly WeatherSummary Scorching = new(10, nameof(Scorching));

    public WeatherSummary(int id, string name) : base(id, name)
    {
    }


    public static IEnumerable<WeatherSummary> List() =>
        new[] { Freezing, Bracing, Chilly, Cool, Mild, Warm, Balmy, Hot, Sweltering, Scorching };


    public static WeatherSummary FromName(string name)
    {
        var state = List()
            .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

        return state ?? throw new Exception($"Possible values for TemplateType: {string.Join(",", List().Select(s => s.Name))}");
    }

    public static WeatherSummary From(int id)
    {
        var state = List().SingleOrDefault(s => s.Id == id);

        return state ?? throw new Exception($"Possible values for TemplateType: {string.Join(",", List().Select(s => s.Name))}");
    }
}
