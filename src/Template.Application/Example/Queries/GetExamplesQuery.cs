using Template.Application.Mediator.Requests;
using Template.Application.Mediator.Results;

namespace Template.Application.Example.Queries;

public sealed class GetExamplesQuery : IApplicationRequest<ApplicationResult<GetExamplesQueryResult, string>>
{
}
