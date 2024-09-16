namespace Template.Application.Abstract;

public interface IRequestHandler<TRequest, TResult>
    where TRequest : IRequest
    where TResult : notnull
{
    public Task<TResult> HandlerAsync( TRequest request );
}