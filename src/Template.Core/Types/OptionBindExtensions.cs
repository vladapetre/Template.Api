namespace Template.Core.Types;

public static class OptionBindExtensions
{
    public static Option<TResult> Continue<TValue, TResult>( this Option<TValue> option, Func<TValue, Option<TResult>> map )
        where TValue : notnull
        where TResult : notnull
        => option.Match(
            onSome: map,
            onNone: () => Option<TResult>.None());

    public static Task<Option<TResult>> ContinueAsync<TValue, TResult>( this Option<TValue> option, Func<TValue, Task<Option<TResult>>> map )
        where TValue : notnull
        where TResult : notnull
        => option.Match(
            onSome: ( value ) => map(value),
            onNone: () => Task.FromResult(Option<TResult>.None()));

    public static async Task<Option<TResult>> ContinueAsync<TValue, TResult>( this Task<Option<TValue>> optionTask, Func<TValue, Task<Option<TResult>>> map )
        where TValue : notnull
        where TResult : notnull
        => await (await optionTask).ContinueAsync(map);

    public static async Task<Option<TResult>> ContinueAsync<TValue, TResult>( this Task<Option<TValue>> optionTask, Func<TValue, Option<TResult>> map )
        where TValue : notnull
        where TResult : notnull
        => await optionTask.ContinueAsync(( value ) => Task.FromResult(map(value)));


}
