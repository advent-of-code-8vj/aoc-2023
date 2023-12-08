using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_wasteland_navigation;

internal class Node
{

    internal string Next(char dir)
    {
        return dir switch
        {
            'L' => _instructions.Item1,
            'R' => _instructions.Item2,
            _ => throw new NotImplementedException()
        };
    }

    internal string Position { get; }
    private Tuple<string, string> _instructions;

    internal Node(string position, Tuple<string, string> instructions)
    {
        Position = position;
        _instructions = instructions;
    }
}

