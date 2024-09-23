namespace Template.Core.Types;

/// <summary>
/// The Maybe monad
/// </summary>
public readonly record struct Option<TValue>
    where TValue : notnull
{
    private readonly TValue? value;

    private Option( TValue? value ) => (this.value) = (value);

    internal static Option<TValue> Some( TValue value ) => new(value);
    internal static Option<TValue> None() => default;

    public TResult Match<TResult>( Func<TValue, TResult> onSome, Func<TResult> onNone )
        => this switch
        {
            { value: not null } => onSome(value),
            { value: null } => onNone(),
        };


    public static implicit operator Option<TValue>( TValue? value ) => new(value);
}

public static class Option
{
    public static Option<TValue> Some<TValue>( TValue value )
        where TValue : notnull
        => Option<TValue>.Some(value);

    public static Option<TValue> None<TValue>()
        where TValue : notnull
        => Option<TValue>.None();

    public static TResult Match<TValue, TResult>( this Option<TValue> option, Func<TValue, TResult> onSome, Func<TResult> onNone )
        where TValue : notnull
        where TResult : notnull
        => option.Match(
            onSome: onSome,
            onNone: onNone);





    //public static async TResult ContinueAsync<TValue, TResult>( this Option<TValue> option, Func<TValue, Task<Option<TResult>>> map )
    //    where TValue : notnull
    //    where TResult : notnull
    //    => await option.Match(
    //        onSome: map,
    //        onNone: () => Task.FromResult(Option<TResult>.None()));

    //public static async Task<Option<TResult>> ContinueAsync<TValue, TResult>( this Task<Option<TValue>> optionTask, Func<TValue, Option<TResult>> map )
    //    where TValue : notnull
    //    where TResult : notnull
    //    => await (await optionTask).ContinueAsync(( value ) => Task.FromResult(map(value)));




    //public static Result<TResult> Map<TValue, TResult>( this Option<TValue> option, Func<TValue, Result<TResult>> onSome, Func<Result<TResult>>? onNone = null )
    //    where TValue : notnull
    //    where TResult : notnull
    //    => option.Match(
    //        onSome: onSome,
    //        onNone: () => onNone switch
    //        {
    //            not null => onNone(),
    //            null => Result.Failure<TResult>(Error.NotFound)
    //        });


    //public static Task<Result<TResult>> MapAsync<TValue, TResult>( this Option<TValue> option, Func<TValue, Task<Result<TResult>>> onSome, Func<Task<Result<TResult>>>? onNone = null )
    //    where TValue : notnull
    //    where TResult : notnull
    //    => option.Match(
    //        onSome: onSome,
    //        onNone: () => onNone switch
    //        {
    //            not null => onNone(),
    //            null => Task.FromResult(Result.Failure<TResult>(Error.NotFound))
    //        });

    //public static async Task<Result<TResult>> MapAsync<TValue, TResult>( this Task<Option<TValue>> optionTask, Func<TValue, Task<Result<TResult>>> onSome, Func<Task<Result<TResult>>>? onNone = null )
    //   where TValue : notnull
    //   where TResult : notnull
    //   => await (await optionTask).MapAsync(
    //        onSome: onSome,
    //        onNone: onNone);


    //public static async Task<Result<TResult>> MapAsync<TValue, TResult>( this Task<Option<TValue>> optionTask, Func<TValue, Result<TResult>> onSome, Func<Result<TResult>>? onNone = null )
    //  where TValue : notnull
    //  where TResult : notnull
    //  => await (await optionTask).MapAsync(
    //        onSome: ( value ) => Task.FromResult(onSome(value)),
    //        onNone: () => onNone switch
    //        {
    //            not null => Task.FromResult(onNone()),
    //            null => Task.FromResult(Result<TResult>.Failure(Error.NotFound))
    //        });
}
