namespace Games.Core;

/// <summary>
/// Represents an interface for an <see cref="IPlayer"/>.
/// </summary>
public interface IPlayer
{
    /// <summary>
    /// Number of turns played.
    /// </summary>
    int TurnCount { get; set; }

    /// <summary>
    /// Player's current points.
    /// </summary>
    int Points { get; set; }
}