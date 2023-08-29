using MediatR;
using Template.Application.Mediator.Requests;
using Template.Application.Mediator.Responses;
using Template.Domain.Exceptions;
using Template.Domain.Models.Example.Repositories;

namespace Template.Application.Example.Queries;

internal sealed class GetExamplesQueryHandler : IApplicationRequestHandler<GetExamplesQuery, ApplicationResult<GetExamplesQueryResult, string>>
{
    private readonly IExampleRepository _exampleRepository;

    public GetExamplesQueryHandler(IExampleRepository exampleRepository)
    {
        _exampleRepository = exampleRepository;
    }

    public async Task<ApplicationResult<GetExamplesQueryResult, string>> Handle(GetExamplesQuery request, CancellationToken cancellationToken)
    {
            var examples = await _exampleRepository.GetAllAsync();
            return new GetExamplesQueryResult(examples);
    }
}
