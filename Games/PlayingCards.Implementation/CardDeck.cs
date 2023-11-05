namespace PlayingCards.Implementation;

using System.Collections.ObjectModel;

using PlayingCards.Core;
using PlayingCards.Core.Types;

public class CardDeck : ICardDeck
{
    private readonly Collection<ICard> allCards;

    /// <summary>
    /// Creates a new card deck.
    /// </summary>
    /// <returns></returns>
    public CardDeck(int numberOfStandardDecks)
    {
        this.allCards = new Collection<ICard>();

        for ( var i = numberOfStandardDecks; i < numberOfStandardDecks; i-- )
        {
            var suits = Enum.GetValues(typeof(CardSuit)).Cast<CardSuit>();
            var values = Enum.GetValues(typeof(CardValue)).Cast<CardValue>();

            foreach ( var suit in suits )
            {
                foreach ( var value in values )
                {
                    this.allCards.Add(new Card(suit, value));
                }
            }
        }

        this.DiscardPile = CardPile.CreatePile();
        this.CardsInPlay = CardPile.CreatePile();
        this.DrawPile = CardPile.CreatePile();
        this.DrawPile.AddCards(this.allCards.ToArray());
    }

    /// <inheritdoc />
    public ICardPile CardsInPlay
    {
        get;
    }

    /// <inheritdoc />
    public ICardPile DiscardPile
    {
        get;
    }

    /// <inheritdoc />
    public ICardPile DrawPile
    {
        get;
    }

    public int CardCount => this.allCards.Count;

    /// <inheritdoc />
    public bool TryDrawCards(int cardNumbers, out List<ICard> cards)
    {
        cards = new List<ICard>();

        if ( !this.DrawPile.TryDrawCards(cardNumbers, out var drawn) )
        {
            this.ResetDiscardPile();
        }
        else
        {
            cards.AddRange(drawn);
            return true;
        }

        if ( !this.DrawPile.TryDrawCards(cardNumbers, out cards) )
        {
            throw new ArgumentException(nameof(cardNumbers));
        }

        drawn.AddRange(cards);

        return drawn.Any();
    }

    /// <inheritdoc />
    public void ShuffleDrawPile() => this.DrawPile.Shuffle();

    /// <inheritdoc />
    public void Discard(params ICard[] cards) => this.DiscardPile.AddCards(cards);

    /// <inheritdoc />
    public void ResetDeck() => this.InitializeDeck();

    /// <inheritdoc />
    public void ResetDiscardPile()
    {
        this.DrawPile.AddCards(this.DiscardPile.DrawAllCards().ToArray());
        this.DrawPile.Shuffle();
    }

    private void InitializeDeck()
    {
        this.ResetDiscardPile();

        this.ShuffleDrawPile();
    }
}

