using MediatR;
using Microsoft.AspNetCore.Mvc;
using Template.Application.Example.Queries;
using Template.Domain.Models.Example;
using Template.Infrastructure.Mappers;

namespace Template.Presentation.Example;

[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper<ExampleAggregateRoot, object> _exampleToObjectMapper;

    public ExampleController(IMediator mediator, IMapper<ExampleAggregateRoot, object> exampleToObjectMapper)
    {
        _mediator = mediator;
        _exampleToObjectMapper = exampleToObjectMapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExampleAggregateRoot>>> Get()
    {
        var getTemplatesQuery = new GetExamplesQuery();

        var getTemplatesQueryResponse = await _mediator.Send(getTemplatesQuery);

        return Ok(getTemplatesQueryResponse.Examples);
    }
}
