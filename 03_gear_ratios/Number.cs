using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_gear_ratios;

internal class Number
{
    internal int Value { get; }
    internal int XStart { get; }
    internal int XEnd { get; }
    internal int Y { get; }

    internal Number(List<int> digits, int xStart, int xEnd, int y)
    {
        Value = NumberFromDigits(digits);
        XStart = xStart;
        XEnd = xEnd;
        Y = y;
    }

    private static int NumberFromDigits(IList<int>digits)
    {
        var value = 0;
        var lastIndex = digits.Count - 1;
        for (var i = 0; i <= lastIndex; i++)
        {
            value += digits[lastIndex - i] * ((int)Math.Pow(10, i));
        }

        return value;
    }

     internal bool IsAdjacentTo(Symbol symbol)
     {
         return symbol.X >= XStart - 1 &&
                symbol.X <= XEnd + 1 &&
                symbol.Y >= Y - 1 &&
                symbol.Y <= Y + 1;
     }

}

