using _09_mirage_maintenance;

Console.WriteLine("AoC 2023 9.12.2023");

// Read a text file line by line.
var path = Path.Combine(Directory.GetCurrentDirectory(), "../../../input.txt");
var lines = File.ReadAllLines(path);

var histories = lines
    .Select(line => line.Trim().Split(" ").Select(s => int.Parse(s.Trim())).ToArray()).ToList();



var sumOfPredictions = histories.Select(s => s[^1] + Helper.Extrapolation(s)).Sum();

var sumOfReversePredictions = histories.Select(s => s[0] - Helper.ReverseExtrapolation(s)).Sum();

Console.WriteLine($"Sum of ExtrapolatedValues: {sumOfPredictions}");

Console.WriteLine($"Sum of Reverse Extrapolated Values: {sumOfReversePredictions}");
