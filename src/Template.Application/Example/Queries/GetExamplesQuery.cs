using Template.Application.Requests;
using Template.Application.Responses;

namespace Template.Application.Example.Queries;

public sealed class GetExamplesQuery : IApplicationRequest<ApplicationResponse<GetExamplesQueryResponse>>
{
}
