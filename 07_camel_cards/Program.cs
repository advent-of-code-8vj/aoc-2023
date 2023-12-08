using _07_camel_cards;

Console.WriteLine("AoC 2023 7.12.2023");

// Read a text file line by line.
var path = Path.Combine(Directory.GetCurrentDirectory(), "../../../input.txt");
var lines = File.ReadAllLines(path);

var games = new List<Game>();

var games2 = new List<Game2>();

foreach (var l in lines)
{
    var line = l.Split(' ');

    var cards= line[0].Trim().ToCharArray();
    var bid = int.Parse(line[1].Trim());

    if (cards.Length != 5) { throw new ArgumentOutOfRangeException(); }
    games.Add(new Game(cards, bid));
    games2.Add(new Game2(cards, bid));
}


foreach (var cardChars in games2.Select(game2 => game2.Cards.Select(s => Game2.PrintCard(s)).ToArray()))
{
    Console.WriteLine(new string(cardChars));
}
Console.WriteLine("---------");
games.Sort(new GameComparer());
games2.Sort(new Game2Comparer());

foreach (var cardChars in games2.Select(game2 => game2.Cards.Select(s => Game2.PrintCard(s)).ToArray()))
{
    Console.WriteLine( new string(cardChars));
}


int totalWinnings = 0;

int totalWinnings2 = 0;


for (int i = 0; i < games.Count; i++)
{
    totalWinnings += (i + 1) * games[i].Bid;

    totalWinnings2 += (i + 1) * games2[i].Bid;
}

Console.WriteLine($"Total Winnings 1: {totalWinnings}");
Console.WriteLine($"Total Winnings 2: {totalWinnings2}");

// Desired order for test input Game 2
//32T3K
//KK677
//T55J5
//QQQJA
//KTJJT


// Desired order for test input Game 1
// 32T3K
// KTJJT
// KK677
// T55J5
// QQQJA
