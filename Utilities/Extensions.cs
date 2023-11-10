namespace Utilities;

/// <summary>
/// Represents extensions for non-project specific classes.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Checks the <see cref="IEnumerable{T}"/> to see if it is null or empty.
    /// </summary>
    /// <typeparam name="T">The type in the <see cref="IEnumerable{T}"/></typeparam>
    /// <param name="enumerable">The <see cref="IEnumerable{T}"/> to check.</param>
    /// <returns>Whether or not the <see cref="IEnumerable{T}"/> is null or empty.</returns>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable) where T : class => enumerable is null || !enumerable.Any();

    /// <summary>
    /// Turns any <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <typeparam name="T">The type in the <see cref="IEnumerable{T}"/></typeparam>
    /// <param name="values">The <see cref="IEnumerable{T}"/> to translate.</param>
    /// <returns>A <see cref="Queue{T}"/> with the <see cref="IEnumerable{T}"/> objects in the initial order given.</returns>
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

