// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices.JavaScript;
using _04_scratchcards;

Console.WriteLine("AoC 2023 4.12.2023");

// Read a text file line by line.
var path = Path.Combine(Directory.GetCurrentDirectory(), "../../../input.txt");
var lines = File.ReadAllLines(path);

var cards = new List<Card>();

foreach (var line in lines)
{
    //Console.WriteLine(line);
    var cardArgs = line.Split(":");
    var cardId = int.Parse(cardArgs[0].Trim("Card ".ToCharArray()));

    var cardNumbers = cardArgs[1].Split("|");

    var winNumbers = cardNumbers[0].Trim().Split(" ")
        .Where(s=> !string.IsNullOrEmpty(s))
        .Select(n=>
            int.Parse(n.Trim()))
        .ToList();
    var scratchedNumbers = cardNumbers[1].Trim().Split(" ")
        .Where(s => !string.IsNullOrEmpty(s))
        .Select(n =>
            int.Parse(n.Trim()))
        .ToList();

    cards.Add(new Card(cardId, winNumbers, scratchedNumbers));
}

var totalPoints =0;

foreach (var card in cards)
{
    totalPoints += card.Points();
}

Console.WriteLine($"Total Points: {totalPoints}");

// Pt2
for (int i = 0; i < cards.Count; i++)
{
    var matches = cards[i].Matches();
    var copies = cards[i].Copies; // The initial 
    for (int j = 1; j <= matches; j++)
    {
        if (j + i >= cards.Count)
            break;

        cards[i+j].AddCopies(copies);
    }

}

var totalCards = 0;

foreach (var card in cards)
{
    totalCards += card.Copies;
}

Console.WriteLine($"Total cards: {totalCards}");
