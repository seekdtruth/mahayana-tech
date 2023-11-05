namespace PlayingCards.Core;

public interface ICardHand
{
    IEnumerable<ICard> Cards { get; }
}
