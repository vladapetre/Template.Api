using MediatR;
using Microsoft.AspNetCore.Mvc;
using Template.Application.Example.Commands;
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
        var getExamplesQuery = new GetExamplesQuery();

        var getExamplesQueryResponse = await _mediator.Send(getExamplesQuery);

        if (getExamplesQueryResponse.Status.Successful)
        {
            return StatusCode(getExamplesQueryResponse.Status.Code, getExamplesQueryResponse.Message);
        }

        return Ok(getExamplesQueryResponse.Result);
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<ExampleAggregateRoot>>> Post()
    {
        var createExampleCommand = new CreateExampleCommand() { Name = "Test"};

        var createExampleCommandResponse = await _mediator.Send(createExampleCommand);

        if (createExampleCommandResponse.Status.Successful)
        {
            return StatusCode(createExampleCommandResponse.Status.Code, createExampleCommandResponse.Message);
        }

        return Ok(createExampleCommandResponse.Result);
    }
}
