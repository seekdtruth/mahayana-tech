namespace PlayingCards.Core;

using PlayingCards.Core.Types;

/// <summary>
/// Represents an interface for an <see cref="ICard"/>
/// </summary>
public interface ICard
{
    /// <summary>
    /// The card's <see cref="CardSuit"/>.
    /// </summary>
    CardSuit CardSuit { get; }

    /// <summary>
    /// The card's <see cref="CardColor"/>
    /// </summary>
    CardColor CardColor { get; }

    /// <summary>
    /// The card's <see cref="CardValue"/>
    /// </summary>
    CardValue CardValue { get; }
}
