using MediatR;
using Template.Application.Mediator.Requests;
using Template.Application.Mediator.Responses;
using Template.Domain.Exceptions;
using Template.Domain.Models.Example.Repositories;

namespace Template.Application.Example.Queries;

internal sealed class GetExamplesQueryHandler : IApplicationRequestHandler<GetExamplesQuery, ApplicationResponse<GetExamplesQueryResponse>>
{
    private readonly IExampleRepository _exampleRepository;

    public GetExamplesQueryHandler(IExampleRepository exampleRepository)
    {
        _exampleRepository = exampleRepository;
    }

    public async Task<ApplicationResponse<GetExamplesQueryResponse>> Handle(GetExamplesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var examples = await _exampleRepository.GetAllAsync();
            return new GetExamplesQueryResponse(examples);
        }
        catch (DomainException domainException)
        {
            return ApplicationResponse.BadRequest(domainException.Message);
        }
        catch (Exception generalException)
        {
            return ApplicationResponse.InternalServerError(generalException.Message);
        }
    }
}
