namespace PlayingCards.Implementation;

using ListRandomizer;

using PlayingCards.Core;

/// <summary>
/// Represents a <see cref="CardPile"/>.
/// </summary>
/// <seealso cref="ICardPile"/>
public class CardPile : ICardPile
{
    private readonly Queue<ICard> cards;

    /// <summary>
    /// Initializes an <see cref="ICardPile"/>.
    /// </summary>
    /// <param name="cards">The cards, if any, to add to the pile.</param>
    /// <returns>An <see cref="ICardPile"/> with the given cards, if any.</returns>
    public static ICardPile CreatePile(params ICard[] cards)
    {
        var pile = new CardPile();
        pile.AddCards(cards);
        return pile;
    }

    /// <summary>
    /// Creates a new instance of <see cref="CardPile"/>
    /// </summary>
    /// <param name="cards">The given cards to add to the pile, if any.</param>
    public CardPile(params ICard[] cards)
    {
        this.cards = new Queue<ICard>();
    }

    /// <inheritdoc />
    public int CardCount => this.cards.Count;

    /// <inheritdoc />
    public void AddCards(params ICard[] cards)
        => cards.ToList().ForEach(card => this.cards.Enqueue(card));

    /// <inheritdoc />
    public bool ContainsCard(ICard card) => this.cards.Contains(card);

    /// <inheritdoc />
    public bool TryDrawCards(int cardsToDraw, out List<ICard> cards)
    {
        cards = new List<ICard>();

        while ( this.cards.TryDequeue(out var card) )
        {
            cardsToDraw--;
            cards.Add(card);
        }

        return cardsToDraw == 0;
    }

    /// <inheritdoc />
    public List<ICard> DrawAllCards()
    {
        var list = this.cards.ToList();
        this.cards.Clear();
        return list;
    }

    /// <inheritdoc />
    public bool Peek() => this.cards.Any();

    /// <inheritdoc />
    public void Shuffle() => this.cards.ToList().Shuffle();
}

