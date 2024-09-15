using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.Abstract;

public sealed class Error
{
    public required string Message { get; init; }
}
