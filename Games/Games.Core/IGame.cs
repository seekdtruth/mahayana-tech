namespace Games.Core;

using System.Collections.Generic;

public interface IGame
{
    /// <summary>
    /// Represents the players in the game.
    /// </summary>
    Queue<IPlayer> Players { get; }

    /// <summary>
    /// Current round number.
    /// </summary>
    int CurrentRound { get; }

    /// <summary>
    /// Maximum number of rounds before ending the game, if applicable.
    /// </summary>
    int? MaxRounds { get; }

    /// <summary>
    /// Setup game starting conditions.
    /// </summary>
    void Initialize();

    /// <summary>
    /// Starts the game play.
    /// </summary>
    void Start();

    /// <summary>
    /// Starts the next player's turn.
    /// </summary>
    void NextTurn();

    /// <summary>
    /// Start's the next round of turns.
    /// </summary>
    void NextRound();

    /// <summary>
    /// Reset's the game to starting game conditions
    /// with same deck and players.
    /// </summary>
    void ResetGame();
}