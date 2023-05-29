using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Example.Queries;
using Template.Application.Mediator.Requests;
using Template.Application.Mediator.Responses;
using Template.Domain.Exceptions;
using Template.Domain.Models.Example.Repositories;

namespace Template.Application.Example.Commands;
public class CreateExampleCommandHandler : IApplicationRequestHandler<CreateExampleCommand, ApplicationResponse<CreateExampleCommandResponse>>
{
    private readonly IExampleRepository _exampleRepository;

    public CreateExampleCommandHandler(IExampleRepository exampleRepository)
    {
        _exampleRepository = exampleRepository;
    }
    public async Task<ApplicationResponse<CreateExampleCommandResponse>> Handle(CreateExampleCommand request, CancellationToken cancellationToken)
    {
  
            var example = await _exampleRepository.CreateExample(request.Name);
            return new CreateExampleCommandResponse(example);
  
    }
}
