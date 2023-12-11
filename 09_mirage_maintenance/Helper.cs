using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_mirage_maintenance;

internal static class Helper
{
    internal static int Extrapolation(int[] values)
    {
        if (Array.TrueForAll( values, v=> v == 0))
        {
            return 0;
        }

        var diffs = new int[values.Length - 1];
        for (var i = 0; i < values.Length - 1; ++i)
        {
            diffs[i] = values[i + 1] - values[i];
        }

        // Last element + extrapolation
        return diffs[^1] + Extrapolation(diffs);
    }

    internal static int ReverseExtrapolation(int[] values)
    {
        if (Array.TrueForAll(values, v => v == 0))
        {
            return 0;
        }

        var diffs = new int[values.Length - 1];
        for (var i = 0; i < values.Length - 1; ++i)
        {
            diffs[i] = values[i + 1] - values[i];
        }

        // first element  - extrapolation
        return diffs[0] - ReverseExtrapolation(diffs);
    }

}

