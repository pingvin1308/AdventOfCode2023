namespace AdventOfCode.Day2;

public static class Solver
{
    public static async Task<int> GetAnswer1()
    {
        var result = 0;

        await foreach (var game in GameSets.GetValues())
        {
            result += game.CanPlay() ? game.GameNumber : 0;
        }

        return result;
    }

    public static async Task<int> GetAnswer2()
    {
        var result = 0;

        await foreach (var game in GameSets.GetValues())
        {
            var maxRed = game.Sets.MaxBy(x => x.Red)?.Red ?? 1;
            var maxGreen = game.Sets.MaxBy(x => x.Green)?.Green ?? 1;
            var maxBlue = game.Sets.MaxBy(x => x.Blue)?.Blue ?? 1;
            result += maxRed * maxGreen * maxBlue;
        }

        return result;
    }
}