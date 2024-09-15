using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Types;

public record struct Result<TValue, TError>
    where TValue : notnull
    where TError : notnull
{
    private readonly TValue? _value;
    private readonly TError? _error;

    private Result(TValue? value, TError? error) => (_value, _error) = (value, error);

    internal static Result<TValue, TError> Success(TValue obj) => new(obj, default);
    internal static Result<TValue, TError> Error(TError err) => new(default, err);

    public TResult Match<TResult>(Func<TValue, TResult> onSuccess, Func<TError, TResult> onError) =>
        this switch
        {
            { _value: not null, _error: null } => onSuccess(_value),
            { _value: null, _error: not null } => onError(_error),
            _ => throw new InvalidOperationException()
        };


    public static implicit operator Result<TValue, TError>(TError error) => Error(error);
    public static implicit operator Result<TValue, TError>(TValue value) => Success(value);
}

public static class Result
{
    public static Result<TValue, TError> Success<TValue, TError>(TValue value)
        where TValue : notnull
        where TError : notnull =>
               Result<TValue, TError>.Success(value);

    public static Result<TValue, TError> Error<TValue, TError>(TError error)
        where TValue : notnull
        where TError : notnull =>
               Result<TValue, TError>.Error(error);
}
