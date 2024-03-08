namespace Template.Application.Abstractions.Requests;
public interface IRequest
{
}

public interface IRequest<TResult>
    where TResult : IResult
{
}
