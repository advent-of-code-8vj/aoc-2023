namespace _02_cube_conondrum;

    
internal class Draw
{
    internal bool IsValid { get; }

    internal Dictionary<Colors, int> ColorCount { get; }

    internal Draw(Dictionary<Colors, int> colorsForDraw, int maxRed, int maxGreen, int maxBlue)
    {
        ColorCount = colorsForDraw;

        IsValid = (colorsForDraw.GetValueOrDefault(Colors.red) <= maxRed) && 
                  (colorsForDraw.GetValueOrDefault(Colors.blue) <= maxBlue) &&
                  (colorsForDraw.GetValueOrDefault(Colors.green) <= maxGreen);
    }

    
}

