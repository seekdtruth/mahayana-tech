namespace PlayingCards.Implementation;

using PlayingCards.Core;
using PlayingCards.Core.Types;

public class Card : ICard
{
    public Card(CardSuit suit, CardValue value)
    {
        this.CardSuit = suit;
        this.CardValue = value;
    }

    public CardSuit CardSuit { get; }

    public CardValue CardValue { get; }

    public CardColor CardColor => this.CardSuit.GetCardColor();
}

