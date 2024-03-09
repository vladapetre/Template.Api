namespace Template.Application.Components.Weather.Queries;
public sealed class GetWeatherQuery : IRequest<Result<GetWeatherQueryResult, Exception>>
{
    public DateTime? Date { get; set; }
}
