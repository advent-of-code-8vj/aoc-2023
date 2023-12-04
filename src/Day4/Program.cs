// See https://aka.ms/new-console-template for more information

using System;
using Day4;

var input = Resource.input;
var result = 0;

foreach (var line in input.Split(Environment.NewLine))
{
	result += Result.Solve(line);
}

Console.WriteLine(result);
Console.ReadLine();