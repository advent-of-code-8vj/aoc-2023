using System.Linq;

namespace Day1;

public class Result
{
	public static int Solve(string text)
	{
		var firstLetter = text.First(x => int.TryParse(x.ToString(), out _));
		var lastLetter = text.Last(x => int.TryParse(x.ToString(), out _));

		return int.Parse($"{firstLetter}{lastLetter}");
	}
}