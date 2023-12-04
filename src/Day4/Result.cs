using System;
using System.Linq;

namespace Day4;

public class Result
{
	public static int Solve(string text)
	{
		var cardStartIndex = text.IndexOf(':') + 2;
		var cardContent = text.Substring(cardStartIndex, text.Length - cardStartIndex);
		var cardParts = cardContent.Split(" | ");
		var winningNumbers = cardParts[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)
			.Select(x => int.Parse(x.Trim())).ToList();
		var cardNumbers = cardParts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)
			.Select(x => int.Parse(x.Trim())).ToList();

		var intersectCount = winningNumbers.Intersect(cardNumbers).Count();
		return (int)Math.Pow(2, intersectCount - 1);
	}
}