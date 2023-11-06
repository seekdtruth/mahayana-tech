namespace PlayingCard.Tests;

using FluentAssertions;

using PlayingCards.Core.Types;
using PlayingCards.Implementation;

using Xunit;

public class PlayingCardsTests
{
    [Fact]
    public void CardPile_AddsAndRemovesCardsCorrectly()
    {
        var cardPile = new CardPile();
        var testCard = new Card(CardSuit.Clubs, CardValue.Nine);

        cardPile.AddCards(testCard);

        cardPile.Should().NotBeNull();
        cardPile.CardCount.Should().Be(1);
        cardPile.Peek().Should().BeTrue();
        cardPile.ContainsCard(testCard).Should().BeTrue();

        cardPile.TryDrawCards(1, out var cards).Should().BeTrue();
        cardPile.Peek().Should().BeFalse();
        cards.Any().Should().BeTrue();
        var card = cards.FirstOrDefault();
        card.Should().NotBeNull();
        card.CardValue.Should().Be(CardValue.Nine);
        card.CardSuit.Should().Be(CardSuit.Clubs);
        card.CardColor.Should().Be(CardColor.Black);
    }

    [Fact]
    public void CardPile_Shuffle_CardsCorrectlyRearranged()
    {
        var cardPile = new CardPile();
        var suits = Enum.GetValues<CardSuit>();
        var values = Enum.GetValues<CardValue>();
        var testCards = suits.SelectMany(suit => values.Select(value => new Card(suit, value))).ToList();

        var initialIndexes = testCards.ToDictionary(
        card => card,
        card => testCards.IndexOf(card));

        cardPile.AddCards(testCards.ToArray());

        cardPile.CardCount.Should().Be(testCards.Count());
        testCards.ToList().ForEach(card => cardPile.ContainsCard(card).Should().BeTrue());
        cardPile.Shuffle();

        var matchingIndexes = 0;

        for ( var i = 0; i < cardPile.CardCount; i++ )
        {
            if ( cardPile.TryDrawCards(1, out var cards) )
            {
                if ( cards.FirstOrDefault() == testCards.ElementAt(1) )
                {
                    matchingIndexes++;
                }
            }
        }

        matchingIndexes.Should().BeLessThanOrEqualTo(2);

        cardPile.AddCards(testCards.ToArray());
        var drawnCards = cardPile.DrawAllCards();
        cardPile.Peek().Should().BeFalse();
        drawnCards.Count().Should().Be(testCards.Count());
    }
}