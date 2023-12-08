using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_camel_cards;

internal class GameComparer : IComparer<Game>
{
    public int Compare(Game? x, Game? y)
    {
        if (x.HandType != y.HandType)
        {
            return x.HandType.CompareTo(y.HandType);
        }
     
        for (var i = 0; i < x.Cards.Length; i++)
        {
            var xCard = x.Cards[i];
            var yCard = y.Cards[i];

            if (xCard != yCard)
            {
                var comparison = xCard.CompareTo(yCard);

                return xCard.CompareTo(yCard);
            }
        }
        
        return 0;
    }
}

