using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Types;

public partial record struct Option<TValue> 
        where TValue : notnull
{
    private TValue? _value;

    public static Option<TValue> Some(TValue obj) => new() { _value = obj };
    public static Option<TValue> None() => new();

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
                onNone: () => Option<TResult>.None());

    public Option<TResult> Map<TResult>(Func<TValue, TResult> map)
        where TResult: notnull =>
            Bind(
                bind: value => Option<TResult>.Some(map(value)));

    public TValue Default(Func<TValue> defaultValue) => 
        Match(
            onSome: value => value, 
            onNone: defaultValue);
}
