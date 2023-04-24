using MediatR;
using Template.Domain.Models.Example.Repositories;

namespace Template.Application.Example.Queries;

internal sealed class GetExamplesQueryHandler : IRequestHandler<GetExamplesQuery, GetExamplesQueryResponse>
{
    private readonly IExampleRepository _exampleRepository;

    public GetExamplesQueryHandler(IExampleRepository exampleRepository)
    {
        _exampleRepository = exampleRepository;
    }

    public async Task<GetExamplesQueryResponse> Handle(GetExamplesQuery request, CancellationToken cancellationToken)
    {
        var examples = await _exampleRepository.GetAllAsync();
        return new(examples);
    }
}
