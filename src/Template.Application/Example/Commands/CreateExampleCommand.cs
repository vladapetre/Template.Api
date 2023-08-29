using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Mediator.Requests;
using Template.Application.Mediator.Results;

namespace Template.Application.Example.Commands;
public class CreateExampleCommand :  IApplicationRequest<ApplicationResult<CreateExampleCommandResult, string>>
{
    public string Name { get; init; } = default!;
}
