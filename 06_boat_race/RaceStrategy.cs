using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_boat_race;

internal static class RaceStrategy
{
    internal static bool IsSuccessful(long velocity, long time, long requiredDistance)
    {
        return velocity * time > requiredDistance;
    }
}

