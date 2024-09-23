using Template.Core.Types;

namespace Template.Application.Abstract;

public interface IRequestHandler<in TRequest, TResult>
    where TRequest : IRequest
    where TResult : notnull
{
    public Task<Result<TResult>> HandlerAsync( TRequest request );
}