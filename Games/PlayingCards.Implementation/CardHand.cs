namespace PlayingCards.Implementation;

using PlayingCards.Core;

public class CardHand : ICardHand
{
    private readonly List<ICard> cards = new();

    public CardHand(params ICard[] cards)
    {
        this.cards = cards.ToList();
    }

    public IEnumerable<ICard> Cards => this.cards;
}
