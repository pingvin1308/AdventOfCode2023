namespace AdventOfCode.Day2;

public record Set(int Red, int Green, int Blue)
{
    public bool CanPlay()
    {
        const int maxRed = 12;
        const int maxGreen = 13;
        const int maxBlue = 14;

        return Red <= maxRed && Green <= maxGreen && Blue <= maxBlue;
    }
}