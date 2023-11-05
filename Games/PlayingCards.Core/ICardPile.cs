namespace PlayingCards.Core;

public interface ICardPile
{
    /// <summary>
    /// Indicates the number of cards in the pile.
    /// </summary>
    int CardCount { get; }

    /// <summary>
    /// Tries to draw cards from the pile.
    /// </summary>
    /// <param name="cardsToDraw">Number of cards to draw.</param>
    /// <param name="cards">The cards drawn from the pile.</param>
    /// <returns>Indicates if the card pile had enough cards to draw.</returns>
    bool TryDrawCards(int cardsToDraw, out List<ICard> cards);

    /// <summary>
    /// Draws the remaining cards from the pile.
    /// </summary>
    /// <returns>All the cards from the pile.</returns>
    List<ICard> DrawAllCards();

    /// <summary>
    /// Adds cards to the pile.
    /// </summary>
    /// <param name="cards">Cards to be added to the pile.</param>
    void AddCards(params ICard[] cards);

    /// <summary>
    /// Checks if a given card is present in the pile.
    /// </summary>
    /// <param name="card">The card to match.</param>
    /// <returns>Whether or not the card is in the pile.</returns>
    bool ContainsCard(ICard card);

    /// <summary>
    /// Shuffles the pile of cards.
    /// </summary>
    void Shuffle();

    /// <summary>
    /// Checks for another card in the pile.
    /// </summary>
    /// <returns></returns>
    bool Peek();
}
