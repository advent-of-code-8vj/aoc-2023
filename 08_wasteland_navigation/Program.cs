using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using _08_wasteland_navigation;

Console.WriteLine("AoC 2023 8.12.2023");

// Read a text file line by line.
var path = Path.Combine(Directory.GetCurrentDirectory(), "../../../input.txt");
var lines = File.ReadAllLines(path);

// List is thread safe for read-only access.
var instructions = lines[0].ToList();
var nodes = new List<Node>();

for (var i = 2; i < lines.Length; i++)
{
    var line = lines[i].Split('=');
    var pos = line[0].Trim();
    var nextNodes = line[1].Trim().Split(',');
    var left = nextNodes[0].Trim().TrimStart('(');
    var right = nextNodes[1].Trim().TrimEnd(')');

    nodes.Add(new Node(pos, new Tuple<string, string>(left, right)));
}


// Part 1:
//var currentNode = nodes.Where(n=> n.Position == "AAA").FirstOrDefault();
//var iter = 0;
//var numberOfInstructions = instructions.Count;

//while (currentNode.Position != "ZZZ")
//{
//    var nextPos = currentNode.Next(instructions[iter % numberOfInstructions]);
//    ++iter;
//    currentNode = nodes.Where(n => n.Position == nextPos).FirstOrDefault();
//}


//Console.WriteLine($"Total iterations Part1:{iter}");


// Part 2:
var iterationsPerPath = new ConcurrentBag<int>();

// Start nodes:
var startNodes = nodes.Where(n => n.Position.EndsWith("A")).ToList();



var iterations = new ConcurrentBag<int>();

var numberOfInstructions = instructions.Count;

Parallel.ForEach(startNodes, node =>
{

    var iter = 0;

    while (!node.Position.EndsWith('Z'))
    {
        var nextPos = node.Next(instructions[iter % instructions.Count]);
        ++iter;
        node = nodes.Where(n => n.Position == nextPos).FirstOrDefault();
    }

    iterations.Add(iter);
});

// Lowers Common Multiplier (LCM)
Console.WriteLine($"Total iterations Part 2: kgv from:");
foreach (var num in iterations)
{
    Console.WriteLine(num);
}

var primeFactors = iterations.Select(n => Helper.PrimeFactors(n)).ToList();

var primeNumbers = primeFactors[0].Keys.ToList();

for (var i = 1; i < primeFactors.Count; i++)
{
    primeNumbers.AddRange(primeFactors[i].Keys.ToList());
}

primeNumbers = primeNumbers.Distinct().ToList();

// long or overflow...
long kgv = 1;

foreach (var p in primeNumbers.Distinct())
{
    var maxFactor = 1;
    foreach (var factor in primeFactors)
    {
        if (factor.TryGetValue(p, out var multiplicity) && multiplicity > maxFactor)
        {
            maxFactor = multiplicity;
        }
    }

    kgv *= (long)Math.Pow(p, maxFactor);
}

Console.WriteLine($"Least common mulitiplier (kgV): {kgv}");
