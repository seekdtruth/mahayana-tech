namespace PlayingCards.Core.Types;

public static class CardTypeExtensions
{
    public static CardColor GetCardColor(this CardSuit suit)
    {
        switch ( suit )
        {
            case CardSuit.Hearts:
            case CardSuit.Diamonds:
                return CardColor.Red;
            default:
                return CardColor.Black;
        }
    }
}
