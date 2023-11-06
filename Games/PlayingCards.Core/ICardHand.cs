namespace PlayingCards.Core;

/// <summary>
/// Represents an interface for an <see cref="ICardHand"/>.
/// </summary>
public interface ICardHand
{
    /// <summary>
    /// The cards in the hand.
    /// </summary>
    IEnumerable<ICard> Cards { get; }
}
