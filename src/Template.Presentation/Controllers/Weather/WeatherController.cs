﻿using System.Net;
using Template.Application.Components.Weather.Queries;
using Template.Presentation.Controllers.Weather.GetWeather;

namespace Template.Presentation.Controllers.Weather;

[ApiController]
[Route("api/{controller}")]
public sealed class WeatherController : ControllerBase
{
    private readonly IRequestHandler<GetWeatherQuery, Result<GetWeatherQueryResult, Exception>> _getWeatherQueryHandler;

    public WeatherController(IRequestHandler<GetWeatherQuery, Result<GetWeatherQueryResult, Exception>> getWeatherQueryHandler)
    {
        _getWeatherQueryHandler = getWeatherQueryHandler;
    }

    [HttpGet]
    public async Task<ActionResult<IList<GetWeatherResponse>>> Get([FromRoute] GetWeatherRequest request)
    {
        var result = await _getWeatherQueryHandler.HandleAsync(new GetWeatherQuery());

        return result.Match<ActionResult>(
                success: (value) => Ok(value.Weather.Select(w => new GetWeatherResponse(w.Date, w.TemperatureC, w.Summary)).ToList()),
                failure: (exception) => StatusCode((int)HttpStatusCode.InternalServerError, exception.Message)
            );
    }
}
