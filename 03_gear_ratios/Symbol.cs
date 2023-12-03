using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_gear_ratios;

internal class Symbol
{
    internal char Value { get; }
    internal int X { get; }

    internal int Y { get; }

    internal Symbol(char value, int x, int y)
    {
        Value = value;
        X = x;
        Y = y;
    }
}

