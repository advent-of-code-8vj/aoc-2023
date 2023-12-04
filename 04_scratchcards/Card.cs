using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_scratchcards;

internal class Card
{
    internal int Id { get; }
    internal IEnumerable<int> WinNumbers { get; }
    internal IEnumerable<int> ScratchNumbers { get; }

    internal int Copies { get; private set; }

    internal void AddCopies(int i)
    {
        Copies +=i;
    }

    internal Card(int id, IEnumerable<int> winNumbers, IList<int> scratchNumbers)
    {
        Id = id;
        WinNumbers = winNumbers.Distinct();
        ScratchNumbers = scratchNumbers.Distinct();
        Copies = 1;
    }

    internal int Matches()
    {
       return WinNumbers.Intersect(ScratchNumbers).AsEnumerable().Count();
    }

    internal int Points()
    {
        var commonNumbers = WinNumbers.Intersect(ScratchNumbers).AsEnumerable();
        int count = commonNumbers.Count();

        if (count == 0)
        {
            return 0;
        }

        var points = 1 * ((int)Math.Pow(2, count - 1));

        return points;
    }
}

