namespace Games.Core;

public interface IPlayer
{
    /// <summary>
    /// Player'sc current turn count.
    /// </summary>
    int TurnCount { get; set; }

    /// <summary>
    /// Player's current points.
    /// </summary>
    int Points { get; set; }
}