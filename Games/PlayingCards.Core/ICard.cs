namespace PlayingCards.Core;

using PlayingCards.Core.Types;

public interface ICard
{
    CardSuit CardSuit { get; }
    CardColor CardColor { get; }
    CardValue CardValue { get; }
}
