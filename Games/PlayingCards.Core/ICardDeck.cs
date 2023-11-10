namespace PlayingCards.Core;

/// <summary>
/// Represents an interface for an <see cref="ICardDeck"/>.
/// </summary>
public interface ICardDeck
{
    /// <summary>
    /// Represents the card pile to be drawn from.
    /// </summary>
    ICardPile DrawPile { get; }

    /// <summary>
    /// Represents cards in the discard pile.
    /// </summary>
    ICardPile DiscardPile { get; }

    /// <summary>
    /// Represents cards currently in play.
    /// </summary>
    ICardPile CardsInPlay { get; }

    /// <summary>
    /// Number of cards in the pile.
    /// </summary>
    int CardCount { get; }

    /// <summary>
    /// Shuffles all cards in the draw pile.
    /// </summary>
    void ShuffleDrawPile();

    /// <summary>
    /// Sends the indicated cards from the draw pile 
    /// or player's hand to the discard pile.
    /// </summary>
    void Discard(params ICard[] card);

    /// <summary>
    /// Resets the deck to its default state.
    /// </summary>
    void ResetDeck();

    /// <summary>
    /// Adds the cards from the discard pile to the 
    /// bottom of the draw pile.
    /// </summary>
    void ResetDiscardPile();
}
