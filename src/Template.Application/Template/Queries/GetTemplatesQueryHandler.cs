using MediatR;
using Template.Domain.Models.Template.Repositories;

namespace Template.Application.Template.Queries;

internal sealed class GetTemplatesQueryHandler : IRequestHandler<GetTemplatesQuery, GetTemplatesQueryResponse>
{
    private readonly ITemplateRepository _templateRepository;

    public GetTemplatesQueryHandler(ITemplateRepository templateRepository)
    {
        _templateRepository = templateRepository;
    }

    public async Task<GetTemplatesQueryResponse> Handle(GetTemplatesQuery request, CancellationToken cancellationToken)
    {
        var templates = await _templateRepository.GetAllAsync();
        return new(templates);
    }
}
