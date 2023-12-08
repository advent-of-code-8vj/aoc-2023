using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_wasteland_navigation;

internal static class Helper
{
    internal static Dictionary<int, int> PrimeFactors(int num)
    {
        var primefactors = new Dictionary<int, int>();

        for (int p = 2; num > 1; p++)
        {
            if (num % p == 0)
            {
                int multiplicity = 0;
                while (num % p == 0)
                {
                    num /= p;
                    multiplicity++;
                }
                primefactors.Add(p, multiplicity);
            }
        }

        return primefactors;
    }

}

