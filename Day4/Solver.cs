namespace AdventOfCode.Day4;

public static class Solver
{
    public static async Task<int> GetAnswer1()
    {
        var sum = 0;
        await foreach (var scratchcard in ScratchcardsReader.GetValues())
        {
            sum += scratchcard.CalcPoints();
        }

        return sum;
    }

    public static async Task<int> GetAnswer2()
    {
        throw new NotImplementedException();
    }
}