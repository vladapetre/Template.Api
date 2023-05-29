using Template.Application.Mediator.Requests;
using Template.Application.Mediator.Responses;

namespace Template.Application.Example.Queries;

public sealed class GetExamplesQuery : IApplicationRequest<ApplicationResponse<GetExamplesQueryResponse>>
{
}
