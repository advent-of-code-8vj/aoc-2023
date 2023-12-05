using System.Runtime.InteropServices.JavaScript;
using System.Xml;
using _05_seed_fertilizer;

Console.WriteLine("AoC 2023 5.12.2023");

// Read a text file line by line.
var path = Path.Combine(Directory.GetCurrentDirectory(), "../../../input.txt");
var lines = File.ReadAllLines(path).ToList();

var lineCount = lines.Count;

// Seeds:
var seedsInput = lines[0].Split(":")[1].Trim().Split(" ").Select(s=> long.Parse(s)).ToList();



// Maps:
var firstMapStart = lines.FindIndex(a => a.Contains("map:", StringComparison.CurrentCultureIgnoreCase)) + 1;
var transformationMaps = new List<SourceToDestionationMap>(){new ()};

for (var i = firstMapStart; i < lineCount; i++)
{
    var line = lines[i];
    if (string.IsNullOrEmpty(line))
    {
        transformationMaps.Add(new SourceToDestionationMap());
        i++;
        continue;
    }

    var values = line.Split(' ').Select(s => long.Parse(s.Trim())).ToList();

    transformationMaps.Last().AddRange(values);
}


// propagate seeds through maps
long Propagate(long seed)
{
    return transformationMaps.Aggregate(seed, (current, transformation) => transformation.GetDestination(current));
}


// Part2: parallelize.. takes a long time.
// possible improvements:
// divide long ranges into smaller ones for further parallelization
// recursive approach?

long minimum = long.MaxValue;
var rangesDefinitions = new List<Tuple<long, long>>();

for (int i = 0; i < seedsInput.Count - 1; i += 2)
{
    rangesDefinitions.Add(new(seedsInput[i], seedsInput[i+1]));
}


object sync = new object();


Parallel.ForEach(rangesDefinitions, range =>
    {
        Console.WriteLine("Start subrange...");
        var seeds = new List<long>();


        // Enumerable.Range not defined for long..
        for (long j = 0; j < range.Item2; j++)
        {
            seeds.Add(range.Item1 + j);
        }

        var minimumForSubrange = seeds.Select(s => Propagate(s)).Min();

        lock (sync)
        {
            minimum = (minimumForSubrange < minimum) ? minimumForSubrange : minimum;
            Console.WriteLine($"Current minimum: {minimum}");
        }
    }
);

// should be 10834440
Console.WriteLine($"Lowest Location: {minimum}");


