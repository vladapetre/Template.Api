using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Types;

public static class Option
{
    public static Option<TValue> None<TValue>() where TValue : notnull =>
            Option<TValue>.None();

    public static Option<TValue> Some<TValue>(TValue value) where TValue : notnull =>
        Option<TValue>.Some(value);

    public static Option<TValue> Create<TValue>(TValue? value) where TValue : class =>
        value is { } some ? Some(some) : None<TValue>();

    public static Option<TValue> Create<TValue>(TValue? value) where TValue : struct =>
        value.HasValue ? Some(value.Value) : None<TValue>();
}
