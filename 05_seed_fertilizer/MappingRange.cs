using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_seed_fertilizer;

internal class MappingRange
{
    internal uint Max { get; }

    internal long Delta { get; }
    internal MappingRange(uint max, long delta)
    {
        Max = max;
        Delta = delta;
    }

    internal uint Map(uint source)
    {
        checked
        {
            return source <= Max ? (uint)(Max + Delta) : source;
        }
    }
}
