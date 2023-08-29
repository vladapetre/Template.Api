﻿using MediatR;
using Template.Application.Mediator.Requests;
using Template.Application.Mediator.Responses;
using Template.Domain.Exceptions;
using Template.Domain.Models.Example.Repositories;

namespace Template.Application.Example.Queries;

internal sealed class GetExamplesQueryHandler : IApplicationRequestHandler<GetExamplesQuery, ApplicationResult<GetExamplesQueryResponse, string>>
{
    private readonly IExampleRepository _exampleRepository;

    public GetExamplesQueryHandler(IExampleRepository exampleRepository)
    {
        _exampleRepository = exampleRepository;
    }

    public async Task<ApplicationResult<GetExamplesQueryResponse, string>> Handle(GetExamplesQuery request, CancellationToken cancellationToken)
    {
            var examples = await _exampleRepository.GetAllAsync();
            return new GetExamplesQueryResponse(examples);
    }
}
