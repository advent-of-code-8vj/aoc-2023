Console.WriteLine("AoC 2023 1.12.2023");

// Read a text file line by line.
var path = Path.Combine(Directory.GetCurrentDirectory(), "../../../input.txt");
var lines = File.ReadAllLines(path);


var stringNumbers = new Dictionary<string, short>()
{
    { "1", 1 },
    { "2", 2 },
    { "3", 3 },
    { "4", 4 },
    { "5", 5 },
    { "6", 6 },
    { "7", 7 },
    { "8", 8 },
    { "9", 9 },
    { "0", 0 },
    // Pt2 only
    { "one", 1 },
    { "two", 2 },
    { "three", 3 },
    { "four", 4 },
    { "five", 5 },
    { "six", 6 },
    { "seven", 7 },
    { "eight", 8 },
    { "nine", 9 },
};


ulong calibrationValueSum = 0;

foreach (var line in lines)
{
    Console.WriteLine(line);

    var lowestIndex = line.Length;
    var highestIndex = -1;

    var firstDigit = 0;
    var lastDigit = 0;


    foreach (var kv in stringNumbers)
    {
        var firstIndex = line.IndexOf(kv.Key, StringComparison.CurrentCultureIgnoreCase);
        var lastIndex = line.LastIndexOf(kv.Key, StringComparison.CurrentCultureIgnoreCase);

        if (firstIndex != -1 && firstIndex < lowestIndex)
        {
            lowestIndex = firstIndex;
            firstDigit = kv.Value;
        }

        if (lastIndex != -1 && lastIndex > highestIndex)
        {
            highestIndex = lastIndex;
            lastDigit = kv.Value;
        }
    }

    if (highestIndex == line.Length || lowestIndex < 0)
    {
        // no values
    }

    var number = 10 * firstDigit + lastDigit;
    Console.WriteLine(number);

    calibrationValueSum += (uint)number;
}

Console.WriteLine($"Calibration Value Sum: {calibrationValueSum}");