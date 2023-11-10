namespace PlayingCards.Implementation;

using PlayingCards.Core;

/// <summary>
/// Represents a <see cref="CardHand"/>.
/// </summary>
/// <seealso cref="ICardHand"/>
public class CardHand : ICardHand
{
    private readonly List<ICard> cards = new();

    /// <summary>
    /// Initializes a new instance of <see cref="CardHand"/>.
    /// </summary>
    /// <param name="cards">The card to add to the hand, if any.</param>
    public CardHand(params ICard[] cards)
    {
        this.cards = cards.ToList();
    }

    /// <inheritdoc />
    public IEnumerable<ICard> Cards => this.cards;
}
