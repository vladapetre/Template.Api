namespace Template.Core.Types;

public static class ResultMapExtensions
{

    public static Result<TResult> Map<TValue, TResult>( this Result<TValue> result, Func<TValue, TResult> map )
        where TValue : notnull
        where TResult : notnull
        => result.Match(
            onSuccess: ( value ) => Result.Success(map(value)),
            onError: ( error ) => Result.Failure<TResult>(error));

    public static Task<Result<TResult>> MapAsync<TValue, TResult>( this Result<TValue> result, Func<TValue, Task<TResult>> map )
        where TValue : notnull
        where TResult : notnull
        => result.Match(
            onSuccess: async ( value ) => Result.Success(await map(value)),
            onError: ( error ) => Task.FromResult(Result.Failure<TResult>(error)));

    public async static Task<Result<TResult>> MapAsync<TValue, TResult>( this Task<Result<TValue>> resultTask, Func<TValue, Task<TResult>> map )
        where TValue : notnull
        where TResult : notnull
        => await (await resultTask).MapAsync(map);

    public async static Task<Result<TResult>> MapAsync<TValue, TResult>( this Task<Result<TValue>> resultTask, Func<TValue, TResult> map )
        where TValue : notnull
        where TResult : notnull
        => await resultTask.MapAsync(( value ) => Task.FromResult(map(value)));
}
