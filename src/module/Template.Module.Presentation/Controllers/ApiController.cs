
using Template.Module.Presentation.Filters;

namespace Template.Module.Presentation.Controllers;


[ServiceFilter(typeof(ValidationFilterAttribute))]
[Route("api")]
public abstract class ApiController : ControllerBase
{
}
