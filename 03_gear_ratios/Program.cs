using System.Globalization;
using _03_gear_ratios;

Console.WriteLine("AoC 2023 3.12.2023");

// Read a text file line by line.
var path = Path.Combine(Directory.GetCurrentDirectory(), "../../../input.txt");
var lines = File.ReadAllLines(path);

// lineindex = y, columnIndex = x;
var input = lines.Select(x => x.ToCharArray()).ToArray();

var symbols = new List<Symbol>();
var numbers = new List<Number>();

// Get Numbers
for (var y = 0; y < lines.Length; y++)
{
    var line = input[y];
    var numberStarted = false;
    var digits = new List<int>();

    for (var x = 0; x < line.Length; x++)
    {
        var c = line[x];
        if (char.IsDigit(c))
        {
            digits.Add((int)char.GetNumericValue(c));
            numberStarted = true;
        }
        else
        {
            if (!numberStarted)
                continue;

            var xStart = x - digits.Count;
            var xEnd = x - 1;
            numbers.Add(new Number(digits, xStart, xEnd, y));

            // reset buffer
            numberStarted = false;
            digits.Clear();
        }

        // Number ends at end of line
        if (numberStarted && x == (line.Length -1))
        {
            var xStart = x - digits.Count;
            var xEnd = x;
            numbers.Add(new Number(digits, xStart, xEnd, y));
            numberStarted = false;
        }

    }
}

// Get Symbols
for (var y = 0; y < lines.Length; y++)
{
    var line = input[y];

    for (var x = 0; x < line.Length; x++)
    {
        var c = line[x];
        if (!char.IsDigit(c) && c != '.')
        {
            symbols.Add(new Symbol(c, x, y));
        }
    }
}

int totalSum = 0;

// Todo: optimize brute force iteration...
foreach (var number in numbers)
{
    foreach (var symbol in symbols)
    {
        if (number.IsAdjacentTo(symbol))
        {
            totalSum += number.Value;

            // numbers with multiple values are counted once only
            break;
        }
    }
}

Console.WriteLine($"Total sum of Part numbers: {totalSum}");

var totalGearRatios = 0;
foreach (var symbol in symbols)
{
    totalGearRatios += symbol.GearRatio();
}

Console.WriteLine($"Total sum of Gear Ratios : {totalGearRatios}");
