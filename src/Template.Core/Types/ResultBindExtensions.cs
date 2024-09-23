namespace Template.Core.Types;

public static class ResultBindExtensions
{
    public static Result<TResult> Continue<TValue, TResult>( this Result<TValue> result, Func<TValue, Result<TResult>> map )
        where TValue : notnull
        where TResult : notnull
        => result.Match(
            onSuccess: map,
            onError: ( error ) => Result.Failure<TResult>(error));

    public static Task<Result<TResult>> ContinueAsync<TValue, TResult>( this Result<TValue> result, Func<TValue, Task<Result<TResult>>> map )
        where TValue : notnull
        where TResult : notnull
        => result.Match(
            onSuccess: map,
            onError: ( error ) => Task.FromResult(Result.Failure<TResult>(error)));

    public async static Task<Result<TResult>> ContinueAsync<TValue, TResult>( this Task<Result<TValue>> resultTask, Func<TValue, Task<Result<TResult>>> map )
        where TValue : notnull
        where TResult : notnull
        => await (await resultTask).ContinueAsync(map);

    public async static Task<Result<TResult>> ContinueAsync<TValue, TResult>( this Task<Result<TValue>> resultTask, Func<TValue, Result<TResult>> map )
        where TValue : notnull
        where TResult : notnull
        => await resultTask.ContinueAsync(( value ) => Task.FromResult(map(value)));
}
