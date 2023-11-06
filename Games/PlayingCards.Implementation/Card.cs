namespace PlayingCards.Implementation;

using PlayingCards.Core;
using PlayingCards.Core.Types;

/// <summary>
/// Represents a <see cref="Card"/>.
/// </summary>
/// <seealso cref="ICard"/>
public class Card : ICard
{
    /// <summary>
    /// Initializes a new instance of a <see cref="Card"/> object.
    /// </summary>
    public Card(CardSuit suit, CardValue value)
    {
        this.CardSuit = suit;
        this.CardValue = value;
    }

    /// <inheritdoc />
    public CardSuit CardSuit { get; }

    /// <inheritdoc />
    public CardValue CardValue { get; }

    /// <inheritdoc />
    public CardColor CardColor => this.CardSuit.GetCardColor();
}

