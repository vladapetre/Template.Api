using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Template.Core.Types;

public partial record class Option<TValue> 
        where TValue : notnull
{
    private TValue? _value;

    private Option() { }

    internal static Option<TValue> Some(TValue obj) => new() { _value = obj };
    internal static Option<TValue> None => new();


    public static implicit operator Option<TValue>(TValue? value) =>
        value switch
        {
            not null => Some(value),
            null => None
        };


    public TResult Match<TResult>(Func<TValue, TResult> onSome, Func<TResult> onNone) =>
        _value switch
        {
            not null => onSome(_value),
            null => onNone()
        };

    public Option<TResult> Bind<TResult>(Func<TValue,Option<TResult>> bind)
        where TResult : notnull =>
            Match(
                onSome: bind,
                onNone: () => Option<TResult>.None);

    public Option<TResult> Map<TResult>(Func<TValue, TResult> map)
        where TResult: notnull =>
            Bind(
                bind: value => Option<TResult>.Some(map(value)));

    public TValue Default(Func<TValue> defaultValue) => 
        Match(
            onSome: value => value, 
            onNone: defaultValue);
}


public static class Option
{
    public static Option<TValue> None<TValue>() where TValue : notnull =>
            Option<TValue>.None;

    public static Option<TValue> Some<TValue>(TValue value) where TValue : notnull =>
        Option<TValue>.Some(value);

    public static Option<TValue> Create<TValue>(TValue? value) where TValue : class =>
        value is { } some ? Some(some) : None<TValue>();

    public static Option<TValue> Create<TValue>(TValue? value) where TValue : struct =>
        value.HasValue ? Some(value.Value) : None<TValue>();
}