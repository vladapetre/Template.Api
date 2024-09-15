using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.Abstract;

public interface IRequestHandler<TRequest, TResult> 
    where TRequest : IRequest
    where TResult : notnull
{
    public Task<TResult> HandlerAsync(TRequest request);
}