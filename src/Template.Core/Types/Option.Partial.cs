using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Types;
/// <summary>
/// https://learn.microsoft.com/en-us/dotnet/api/system.collections.istructuralequatable?view=net-8.0
/// https://github.com/Andreas-Dorfer/functional-extensions/blob/master/src/AD.FunctionalExtensions/Option.cs
/// </summary>
/// <typeparam name="TValue"></typeparam>
public partial record struct Option<TValue> : IEquatable<Option<TValue>>, IComparable<Option<TValue>>, IComparable
{
    public int CompareTo(object? other) =>
     other switch
     {
         Option<TValue> obj => CompareTo(obj),
         _ => throw new ArgumentException(nameof(other))
     };

    public int CompareTo(Option<TValue> other) =>
       CompareTo(other, Comparer<TValue>.Default);

    public int CompareTo(Option<TValue> other, IComparer<TValue> comparer) =>
        comparer switch
        {
            not null => CompareTo(other, comparer.Compare),
            null => throw new ArgumentNullException(nameof(comparer))
        };

    private int CompareTo(Option<TValue> other, Func<TValue, TValue, int> compare)
    {
        if (_value is null)
        {
            return other._value is not null ? -1 : 0;
        }
        return other._value is null ? 1 : compare(_value, other._value);
    }

    public static bool operator <(Option<TValue> a, Option<TValue> b) =>
       a.CompareTo(b) < 0;

    public static bool operator >(Option<TValue> a, Option<TValue> b) =>
        a.CompareTo(b) > 0;

    public static bool operator <=(Option<TValue> a, Option<TValue> b) =>
        a.CompareTo(b) <= 0;

    public static bool operator >=(Option<TValue> a, Option<TValue> b) =>
        a.CompareTo(b) >= 0;

    public override string ToString() => _value is not null ? $"Some({_value})" : "None";
}
