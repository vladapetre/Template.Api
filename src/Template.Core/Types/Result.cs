namespace Template.Core.Types;

public readonly record struct Result<TValue>
    where TValue : notnull
{
    private readonly TValue? value;
    private readonly Error? error;

    private Result( TValue? value, Error? error ) => (this.value, this.error) = (value, error);

    internal static Result<TValue> Success( TValue value ) => new(value, default);
    internal static Result<TValue> Failure( Error error ) => new(default, error);

    internal TResult Match<TResult>( Func<TValue, TResult> onSuccess, Func<Error, TResult> onError )
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

    public static TResult Match<TValue, TError, TResult>( this Result<TValue> result, Func<TValue, TResult> onSuccess, Func<Error, TResult> onError )
        where TValue : notnull
        => result.Match(
            onSuccess: onSuccess,
            onError: onError);

    public static Result<TResult> Continue<TValue, TResult>( this Result<TValue> result, Func<TValue, Result<TResult>> onSuccess, Func<Error, Result<TResult>> onError )
        where TValue : notnull
        where TResult : notnull
        => result.Match(
            onSuccess: onSuccess,
            onError: onError);

    public static Task<Result<TResult>> ContinueAsync<TValue, TResult>( this Result<TValue> result, Func<TValue, Task<Result<TResult>>> onSuccess, Func<Error, Task<Result<TResult>>> onError )
        where TValue : notnull
        where TResult : notnull
        => result.Match(
            onSuccess: onSuccess,
            onError: onError);

    public async static Task<Result<TResult>> ContinueAsync<TValue, TResult>( this Task<Result<TValue>> resultTask, Func<TValue, Task<Result<TResult>>> onSuccess, Func<Error, Task<Result<TResult>>> onError )
        where TValue : notnull
        where TResult : notnull
        => await (await resultTask).Match(
            onSuccess: onSuccess,
            onError: onError);

    public async static Task<Result<TResult>> ContinueAsync<TValue, TResult>( this Task<Result<TValue>> resultTask, Func<TValue, Result<TResult>> onSuccess, Func<Error, Result<TResult>> onError )
        where TValue : notnull
        where TResult : notnull
        => await (await resultTask).ContinueAsync(
            onSuccess: ( value ) => Task.FromResult(onSuccess(value)),
            onError: ( error ) => Task.FromResult(onError(error)));






    public static Option<TResult> Map<TValue, TResult>( this Result<TValue> result, Func<TValue, Option<TResult>> onSuccess, Func<Error, Option<TResult>>? onError = null )
        where TValue : notnull
        where TResult : notnull
        => result.Match(
            onSuccess: onSuccess,
            onError: ( error ) => onError switch
            {
                not null => onError(error),
                null => Option<TResult>.None()
            });


    public static Task<Option<TResult>> MapAsync<TValue, TResult>( this Result<TValue> result, Func<TValue, Task<Option<TResult>>> onSuccess, Func<Error, Task<Option<TResult>>>? onError = null )
        where TValue : notnull
        where TResult : notnull
        => result.Match(
            onSuccess: onSuccess,
            onError: ( error ) => onError switch
            {
                not null => onError(error),
                null => Task.FromResult(Option<TResult>.None())
            });

    public static async Task<Option<TResult>> MapAsync<TValue, TResult>( this Task<Result<TValue>> resultTask, Func<TValue, Task<Option<TResult>>> onSuccess, Func<Error, Task<Option<TResult>>>? onError = null )
       where TValue : notnull
       where TResult : notnull
       => await (await resultTask).MapAsync(
           onSuccess: onSuccess,
           onError: onError);


    public static async Task<Option<TResult>> MapAsync<TValue, TResult>( this Task<Result<TValue>> resultTask, Func<TValue, Option<TResult>> onSuccess, Func<Error, Option<TResult>>? onError = null )
      where TValue : notnull
      where TResult : notnull
      => await (await resultTask).MapAsync(
          onSuccess: ( value ) => Task.FromResult(onSuccess(value)),
          onError: ( error ) => onError switch
          {
              not null => Task.FromResult(onError(error)),
              null => Task.FromResult(Option<TResult>.None())
          });
}
