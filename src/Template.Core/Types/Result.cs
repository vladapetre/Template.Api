namespace Template.Core.Types;

public readonly record struct Result<TValue>
    where TValue : notnull
{
    private readonly TValue? value;
    private readonly Error? error;

    private Result( TValue? value, Error? error ) => (this.value, this.error) = (value, error);

    internal static Result<TValue> Success( TValue value ) => new(value, default);
    internal static Result<TValue> Failure( Error error ) => new(default, error);

    public TResult Match<TResult>( Func<TValue, TResult> onSuccess, Func<Error, TResult> onError )
       => this switch
       {
           { value: not null, error: null } => onSuccess(value),
           { value: null, error: not null } => onError(error.Value),
           _ => throw new NotImplementedException()
       };

    public static implicit operator Result<TValue>( TValue value ) => Success(value);
    public static implicit operator Result<TValue>( Error error ) => Failure(error);

}

public static class Result
{
    public static Result<TValue> Success<TValue>( TValue value )
        where TValue : notnull
        => Result<TValue>.Success(value);

    public static Result<TValue> Failure<TValue>( Error error )
        where TValue : notnull
        => Result<TValue>.Failure(error);

    public static TResult Match<TValue, TResult>( this Result<TValue> result, Func<TValue, TResult> onSuccess, Func<Error, TResult> onError )
        where TValue : notnull
        => result.Match(
            onSuccess: onSuccess,
            onError: onError);
}
