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
}
