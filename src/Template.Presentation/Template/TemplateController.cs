using MediatR;
using Microsoft.AspNetCore.Mvc;
using Template.Application.Queries.Template;
using Template.Domain.Models.Template;
using Template.Infrastructure.Template.Mappers;

namespace Template.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemplateController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITemplateMapper<TemplateAggregateRoot, object> _templateToObjectMapper;

        public TemplateController(IMediator mediator, ITemplateMapper<TemplateAggregateRoot, object> templateToObjectMapper)
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
}