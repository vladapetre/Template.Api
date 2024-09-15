using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Types;

public record class Result<TValue, TError> 
    where TValue : notnull
    where TError : notnull 
{
    private TValue? _value;
    private TError? _error;

    private Result() { }

    internal static Result<TValue, TError> Success(TValue obj) => new() { _value = obj, _error = default };
    internal static Result<TValue, TError> Error(TError err) => new() { _value = default, _error = err };

    public TResult Match<TResult>(Func<TValue, TResult> onSuccess, Func<TError, TResult> onError) =>
        this switch
        {
            { _value : not null} => onSuccess(_value),
            { _error: not null} => onError(_error),
            _ => throw new InvalidOperationException()
        };


    public static implicit operator Result<TValue,TError>(TError error) => Error(error);
    public static implicit operator Result<TValue, TError>(TValue value) => Success(value);
}

public static class Result
{
    public static Result<TValue,TError> Success<TValue, TError>(TValue value) 
        where TValue : notnull 
        where TError : notnull =>
               Result<TValue,TError>.Success(value);

    public static Result<TValue, TError> Error<TValue, TError>(TError error)
        where TValue : notnull
        where TError : notnull =>
               Result<TValue, TError>.Error(error);
}
