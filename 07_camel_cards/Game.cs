using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_camel_cards;

internal class Game
{
    internal Card[] Cards { get; }

    internal int Bid { get; }

    internal HandType HandType { get; }


    internal Game(char[] cardSymbols, int bid)
    {
        var cards = cardSymbols
            .Select(s => ParseCard(s)).ToArray();

        Cards = cards;
        
        Bid = bid;

        HandType = GetHandType(cards);
    }
    
    private static HandType GetHandType(Card[] hand)
    {
        var histogram = hand.GroupBy(c => c).Select(c => c.Count()).ToList();

        return histogram.Count switch
        {
            1 => HandType.FiveOfAKind,
            2 when histogram.Max() == 4 => HandType.FourOfAKind,
            2 when histogram.Max() == 3 => HandType.FullHouse,
            3 when histogram.Max() == 3 => HandType.ThreeOfAKind,
            3 when histogram.Max() == 2 => HandType.TwoPair,
            4 => HandType.OnePair,
            _ => HandType.HighCard,
        };
    }



    internal static char PrintCard(Card card)
    {
        return card switch
        {
            Card.Two => '2',
            Card.Three => '3',
            Card.Four => '4',
            Card.Five => '5',
            Card.Six => '6',
            Card.Seven => '7',
            Card.Eight => '8',
            Card.Nine => '9',
            Card.Ten => 'T',
            Card.Jack => 'J',
            Card.Queen => 'Q',
            Card.King => 'K',
            Card.Ace => 'A',
        };
    }

    private static Card ParseCard(char c)
    {
        return c switch
        {
            '2' => Card.Two,
            '3' => Card.Three,
            '4' => Card.Four,
            '5' => Card.Five,
            '6' => Card.Six,
            '7' => Card.Seven,
            '8' => Card.Eight,
            '9' => Card.Nine,
            'T' => Card.Ten,
            'J' => Card.Jack,
            'Q' => Card.Queen,
            'K' => Card.King,
            'A' => Card.Ace,
            _ => throw new ArgumentOutOfRangeException("c"),
        };
    }
}

