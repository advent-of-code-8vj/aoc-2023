using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_cube_conondrum;

internal class Game
{
    private readonly List<Draw> _draws = new();

    internal int Id { get; }

    internal Game(string name, string[] drawList, int maxRed, int maxGreen, int maxBlue)
    {
        Id = int.Parse(name.Split(" ")[1]);

        foreach (var draw in drawList)
        {
            Dictionary<Colors, int> colorsForDraw = new()
            {
                { Colors.red, 0 },
                { Colors.blue, 0 },
                { Colors.green, 0 },
            };

            foreach (var color in draw.Split(','))
            {
                foreach (var colorCandidate in Enum.GetNames(typeof(Colors)))
                {
                    if (!color.Trim().EndsWith(colorCandidate))
                        continue;
                    
                    var count = int.Parse(color.Trim().Split(" ")[0]);

                    colorsForDraw[Enum.Parse<Colors>(colorCandidate)] = count;
                }
            }

            _draws.Add(new Draw(colorsForDraw, maxRed, maxGreen, maxBlue));

        }
    }

    internal int Power()
    {
        var maxRed = _draws.Select(d => d.ColorCount[Colors.red]).Max();
        var maxBlue = _draws.Select(d => d.ColorCount[Colors.blue]).Max();
        var maxGreen = _draws.Select(d => d.ColorCount[Colors.green]).Max();

        return maxRed * maxGreen * maxBlue;
    }

    internal bool IsPossible()
    {
        return _draws.Aggregate(true, (current, draw) => current && draw.IsValid);
    }
}

