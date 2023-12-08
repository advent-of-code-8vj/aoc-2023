using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _07_camel_cards;

internal class Game2
{
    internal Card2[] Cards { get; }

    internal int Bid { get; }

    internal HandType HandType { get; }


    internal Game2(char[] cardSymbols, int bid)
    {
        var cards = cardSymbols
            .Select(s => ParseCard(s)).ToArray();

        Cards = cards;
        Bid = bid;
        HandType = GetHandType(cards);
    }
    
    private static HandType GetHandType(Card2[] hand)
    {
        // remove jokers from histogram
        var numOfjokers = hand.Where(c => c.Equals(Card2.Joker)).Count();


        var histogram = hand
            .Where(c => !(c.Equals(Card2.Joker)))
            .GroupBy(c => c)
            .Select(c => c.Count()).ToList();

        // Maximize joker effect: joker is added as this card with highest count
        if (histogram.Any())
        {
            var maxIndex = histogram.IndexOf(histogram.Max());
            histogram[maxIndex] += numOfjokers;
        }
        else
        {
            // case with 5 jokers..
            histogram.Add(numOfjokers);
        }
            

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



    internal static char PrintCard(Card2 card)
    {
        return card switch
        {
            Card2.Two => '2',
            Card2.Three => '3',
            Card2.Four => '4',
            Card2.Five => '5',
            Card2.Six => '6',
            Card2.Seven => '7',
            Card2.Eight => '8',
            Card2.Nine => '9',
            Card2.Ten => 'T',
            Card2.Joker => 'J',
            Card2.Queen => 'Q',
            Card2.King => 'K',
            Card2.Ace => 'A',
        };
    }

    private static Card2 ParseCard(char c)
    {
        return c switch
        {
            '2' => Card2.Two,
            '3' => Card2.Three,
            '4' => Card2.Four,
            '5' => Card2.Five,
            '6' => Card2.Six,
            '7' => Card2.Seven,
            '8' => Card2.Eight,
            '9' => Card2.Nine,
            'T' => Card2.Ten,
            'J' => Card2.Joker,
            'Q' => Card2.Queen,
            'K' => Card2.King,
            'A' => Card2.Ace,
            _ => throw new ArgumentOutOfRangeException("c"),
        };
    }
}

