namespace PlayingCards.Implementation;

using System.Collections.ObjectModel;

using PlayingCards.Core;
using PlayingCards.Core.Types;

/// <summary>
/// Represents a <see cref="CardDeck"/>
/// </summary>
/// <seealso cref="ICardDeck" />
public class CardDeck : ICardDeck
{
    private readonly Collection<ICard> allCards;

    /// <summary>
    /// Creates a new instance of a <see cref="CardDeck"/> object.
    /// </summary>
    /// <param name="numberOfStandardDecks">The number of standard playing card decks to include in the <see cref="CardDeck"/></param>
    /// <returns>A new <see cref="CardDeck"/> with the given number of decks.</returns>
    /// <remarks>A standard playing card deck assumes 52 cards total with four suits and thirteen value cards per suit.</remarks>
    public CardDeck(int numberOfStandardDecks = 1)
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
    /// <exception cref="ArgumentOutOfRangeException">Thrown if a given card is not available to be discarded.</exception>
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

