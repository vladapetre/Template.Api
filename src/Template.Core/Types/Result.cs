using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Types;

public record struct Result<TValue>
    where TValue : notnull
{
    private TValue _value;
}

public record struct Result<TValue, TError> 
    where TValue : notnull
{
    private TValue _value;
    private TError _error;
}
