using Template.Application.Abstractions.Requests;

namespace Template.Application.Abstractions.Results;
public sealed class Result<TValue, TError> : IResult
{
    public TValue? Value { get; private init; }
    public TError? Error { get; private init; }

    private bool _isSuccess;

    private Result(TValue value)
    {
        _isSuccess = true;
        Value = value;
        Error = default;
    }

    private Result(TError error)
    {
        _isSuccess = false;
        Value = default;
        Error = error;
    }

    //happy path
    public static implicit operator Result<TValue, TError>(TValue value) => new Result<TValue, TError>(value);

    //error path
    public static implicit operator Result<TValue, TError>(TError error) => new Result<TValue, TError>(error);

    public TOut Match<TOut>(Func<TValue, TOut> success, Func<TError, TOut> failure)
    {
        if (_isSuccess)
        {
            return success(Value!);
        }
        return failure(Error!);
    }
}
