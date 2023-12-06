using _06_boat_race;

Console.WriteLine("AoC 2023 6.12.2023");

// Read a text file line by line.
var path = Path.Combine(Directory.GetCurrentDirectory(), "../../../input2.txt");
var lines = File.ReadAllLines(path);

var times = lines[0].Split(" ").Where(s=> !string.IsNullOrEmpty(s)).Skip(1).Select(s=> long.Parse(s)).ToList();
var distances = lines[1].Split(" ").Where(s => !string.IsNullOrEmpty(s)).Skip(1).Select(s => long.Parse(s)).ToList();

var races = new List<Tuple<long, long, int>>();
for(int i = 0; i < times.Count; ++i)
{
    races.Add(new(times[i], distances[i], i));
}


object sync = new object();

long strategyProduct = 1;

Parallel.ForEach(races, race =>
{
    Console.WriteLine($"Calculating Race {race.Item3}");

    int numberOfStrategys = 0;

    for (int i = 1; i < race.Item1 - 1; ++i)
    {
        // velocity = accelerationTime
        var accelerationTime = i;
        var glidingTime = race.Item1 - i;
        var distance = race.Item2;

        if (RaceStrategy.IsSuccessful(accelerationTime, glidingTime, distance))
        {
            numberOfStrategys++;
        }
    }

    lock (sync)
    {
        if (numberOfStrategys > 0)
        {
            strategyProduct *= numberOfStrategys;
        }
    }
});

Console.WriteLine($"Product: {strategyProduct}");
