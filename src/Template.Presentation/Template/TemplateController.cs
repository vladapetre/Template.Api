using MediatR;
using Microsoft.AspNetCore.Mvc;
using Template.Application.Template.Queries;
using Template.Domain.Models.Template;
using Template.Infrastructure.Mappers;

namespace Template.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TemplateController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper<TemplateAggregateRoot, object> _templateToObjectMapper;

    public TemplateController(IMediator mediator, IMapper<TemplateAggregateRoot, object> templateToObjectMapper)
    {
        _mediator = mediator;
        _templateToObjectMapper = templateToObjectMapper;
    }

    [HttpGet] 
    public async Task<ActionResult<IEnumerable<object>>> Get()
    {
        var getTemplatesQuery = new GetTemplatesQuery();

        var getTemplatesQueryResponse = await _mediator.Send(getTemplatesQuery);

        return Ok(getTemplatesQueryResponse.Templates?.Select(template => _templateToObjectMapper.Map(template)));
    }
}