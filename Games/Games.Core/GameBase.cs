namespace Games.Core;

using Utilities;

public abstract class GameBase : IGame
{
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