using _02_cube_conondrum;

Console.WriteLine("AoC 2023 2.12.2023");

// Read a text file line by line.
var path = Path.Combine(Directory.GetCurrentDirectory(), "../../../input.txt");
var lines = File.ReadAllLines(path);


const int maxRed = 12;
const int maxGreen = 13;
const int maxBlue = 14;

var sumOfPossibleGameIds = 0;
var sumOfGamePowers = 0;

foreach (var line in lines)
{
    Console.WriteLine(line);

    var arguments = line.Split(":");
    var gameId = arguments[0].Trim();
    var draws = arguments[1].Split(";");


    var game = new Game(gameId, draws, maxRed, maxGreen, maxBlue);

    if (game.IsPossible())
    {
        sumOfPossibleGameIds += game.Id;
    }

    sumOfGamePowers += game.Power();
}

Console.WriteLine($"Sum of possible Game ids: {sumOfPossibleGameIds}");
Console.WriteLine($"Sum of all Game powers: {sumOfGamePowers}");
