namespace Games.Core;

using Utilities;

/// <summary>
/// Represents an abstract class for an <see cref="IGame"/>.
/// </summary>
public abstract class GameBase : IGame
{
    /// <summary>
    /// Initializes a new instance of <see cref="GameBase"/>.
    /// </summary>
    /// <param name="players">Players to be added to the game.</param>
    protected GameBase(params IPlayer[] players)
    {
        this.Players = !players.IsNullOrEmpty() ? new Queue<IPlayer>(players) : new Queue<IPlayer>();
    }

    /// <inheritdoc />
    public Queue<IPlayer> Players { get; }

    /// <inheritdoc />
    public abstract void Start();

    /// <inheritdoc />
    public abstract void Initialize();

    /// <inheritdoc />
    public abstract void NextTurn();

    /// <inheritdoc />
    public abstract void NextRound();

    /// <inheritdoc />
    public abstract void EndRound();

    /// <inheritdoc />
    public abstract void ResetGame();

    /// <inheritdoc />
    public int CurrentRound
    {
        get; set;
    }

    /// <inheritdoc />
    public int? MaxRounds
    {
        get; set;
    }
}