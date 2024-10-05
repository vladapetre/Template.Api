namespace Template.Core.Types;

public static class Nullable
{
    public static TResult Match<TValue, TResult>( this TValue? nullable, Func<TValue, TResult> onValue, Func<TResult> onNull )
        => nullable switch
        {
            not null => onValue(nullable),
            null => onNull()
        };

    public static TResult? Continue<TValue, TResult>( this TValue? nullable, Func<TValue, TResult> map )
        => nullable.Match<TValue, TResult?>(
            onValue: ( value ) => map(value),
            onNull: () => default);

    public async static Task<TResult?> ContinueAsync<TValue, TResult>( this TValue? nullable, Func<TValue, Task<TResult>> map )
        => await nullable.Match<TValue, Task<TResult?>>(
            onValue: async ( value ) => await map(value),
            onNull: () => Task.FromResult(default(TResult?)));

    public async static Task<TResult?> ContinueAsync<TValue, TResult>( this Task<TValue?> optionTask, Func<TValue, Task<TResult>> map )
        => await (await optionTask).ContinueAsync(map);

    public async static Task<TResult?> ContinueAsync<TValue, TResult>( this Task<TValue?> optionTask, Func<TValue, TResult> map )
        => await optionTask.ContinueAsync(( value ) => Task.FromResult(map(value)));

    public static TValue GetValueOrThrow<TValue, TException>( this TValue? nullable, TException exception )
        where TException : Exception
        => nullable.Match(
            onValue: ( value ) => value,
            onNull: () => throw exception);
}
