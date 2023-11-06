namespace Utilities;

public static class Extensions
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable) where T : class => enumerable is null || !enumerable.Any();

    public static Queue<T> ToQueue<T>(this IEnumerable<T> values) where T : class
    {
        var queue = new Queue<T>();

        foreach ( var item in values )
        {
            queue.Enqueue(item);
        }

        return queue;
    }
}

