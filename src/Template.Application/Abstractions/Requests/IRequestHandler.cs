namespace Template.Application.Abstractions.Requests;
public interface IRequestHandler<TRequest>
    where TRequest : IRequest
{
    Task HandleAsync(TRequest request);
}

public interface IRequestHandler<TRequest, TResult>
    where TRequest : IRequest<TResult>
    where TResult : IResult
{
    Task<TResult> HandleAsync(TRequest request);
}
