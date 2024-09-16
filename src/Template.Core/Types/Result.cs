namespace Template.Core.Types;


file readonly record struct Result<TError>
    where TError : notnull
{
    private readonly TError? error;

    private Result( TError? error ) => (this.error) = (error);

    internal static Result<TError> Success() => new(default);
    internal static Result<TError> Error( TError err ) => new(err);

    public TResult Match<TResult>( Func<TResult> onSuccess, Func<TError, TResult> onError ) =>
        this switch
        {
            { error: null } => onSuccess(),
            { error: not null } => onError(error),
        };

    public static implicit operator Result<TError>( TError error ) => Error(error);
}


file readonly record struct Result<TValue, TError>
    where TValue : notnull
    where TError : notnull
{
    private readonly TValue? value;
    private readonly TError? error;

    private Result( TValue? value, TError? error ) => (this.value, this.error) = (value, error);

    internal static Result<TValue, TError> Success( TValue obj ) => new(obj, default);
    internal static Result<TValue, TError> Error( TError err ) => new(default, err);

    public TResult Match<TResult>( Func<TValue, TResult> onSuccess, Func<TError, TResult> onError ) =>
        this switch
        {
            { value: not null, error: null } => onSuccess(value),
            { value: null, error: not null } => onError(error),
            _ => throw new InvalidOperationException()
        };


    public static implicit operator Result<TValue, TError>( TError error ) => Error(error);
    public static implicit operator Result<TValue, TError>( TValue value ) => Success(value);
}

file static class Result
{
    public static Result<TValue, TError> Success<TValue, TError>( TValue value )
        where TValue : notnull
        where TError : notnull =>
               Result<TValue, TError>.Success(value);

    public static Result<TValue, TError> Error<TValue, TError>( TError error )
        where TValue : notnull
        where TError : notnull =>
               Result<TValue, TError>.Error(error);

    public static Result<TError> Success<TError>()
        where TError : notnull =>
               Result<TError>.Success();

    public static Result<TError> Error<TError>( TError error )
        where TError : notnull =>
               Result<TError>.Error(error);
}
