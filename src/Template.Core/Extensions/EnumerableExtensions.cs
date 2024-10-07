namespace Template.Core.Extensions;
public static class EnumerableExtensions
{
    public static void Execute<T>( this IEnumerable<T> enumerable, Action<T> action )
    {
        foreach (var item in enumerable)
        {
            action(item);
        }
    }

    public static async Task ExecuteAsync<T>( this IEnumerable<T> enumerable, Func<T, Task> action )
    {
        foreach (var item in enumerable)
        {
            await action(item);
        }
    }
}
