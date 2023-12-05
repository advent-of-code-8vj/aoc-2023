using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _05_seed_fertilizer;

internal class SourceToDestionationMap
{

    // min, max, shift
    private List<Tuple<long, long, long>> mappingRanges = new ();





    internal void AddRange(IList<long> mapping)
    {
        // destination start, source start, range


        // mapping to range corresponds to shift +-

        var sourceMin = mapping[1];
        var sourceMax = sourceMin + mapping[2] - 1;
        var mappingShift = mapping[0] - mapping[1];

        mappingRanges.Add( new (sourceMin, sourceMax, mappingShift));
    }


    public long GetDestination(long source)
    {
        var applicableMappings = mappingRanges.Where(t => source >= t.Item1 && source <= t.Item2);

        var numberOfMappings = applicableMappings.Count();

        if (numberOfMappings > 1)
        {
            throw new Exception("overlapping mappings");
        }

        var delta = numberOfMappings == 1 ? applicableMappings.First().Item3 : 0;


        checked
        {
            return (long)(source + delta);
        }
    }
}

