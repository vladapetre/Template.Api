using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Models.Example;

namespace Template.Application.Example.Commands;
public class CreateExampleCommandResponse
{
    public CreateExampleCommandResponse(ExampleAggregateRoot example)
    {
        Example = example;
    }

    public ExampleAggregateRoot Example { get; private init; }
}
