namespace Template.Core.Types;

public static class OptionMapExtensions
{
    public static Option<TResult> Map<TValue, TResult>( this Option<TValue> option, Func<TValue, TResult> map )
        where TValue : notnull
        where TResult : notnull
        => option.Match(
            onSome: ( value ) => Option.Some(map(value)),
            onNone: () => Option.None<TResult>());

    public async static Task<Option<TResult>> MapAsync<TValue, TResult>( this Option<TValue> option, Func<TValue, Task<TResult>> map )
        where TValue : notnull
        where TResult : notnull
        => await option.Match(
            onSome: async ( value ) => Option.Some(await map(value)),
            onNone: () => Task.FromResult(Option.None<TResult>()));
    public async static Task<Option<TResult>> MapAsync<TValue, TResult>( this Task<Option<TValue>> optionTask, Func<TValue, Task<TResult>> map )
        where TValue : notnull
        where TResult : notnull
        => await (await optionTask).MapAsync(map);

    public async static Task<Option<TResult>> MapAsync<TValue, TResult>( this Task<Option<TValue>> optionTask, Func<TValue, TResult> map )
        where TValue : notnull
        where TResult : notnull
        => await optionTask.MapAsync(( value ) => Task.FromResult(map(value)));
}
