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
        var scratchcards = ScratchcardsReader.GetValues().ToBlockingEnumerable().ToArray();
        var copiesMap = new Dictionary<int, int>();
        const int originalCopies = 1;
        for (var i = 0; i < scratchcards.Length; i++)
        {
            if (!copiesMap.TryGetValue(i, out var copies))
            {
                copies = originalCopies;
            }
            else
            {
                copies += originalCopies;
            }

            var nextCopies = scratchcards[i].GetNextCopies();
            for (var k = 0; k < copies; k++)
            {
                for (var j = i + 1; j < i + 1 + nextCopies; j++)
                {
                    if (copiesMap.ContainsKey(j))
                    {
                        copiesMap[j]++;
                    }
                    else
                    {
                        copiesMap[j] = 1;
                    }
                }
            }
        }

        var sum = 0;
        for (var i = 0; i < scratchcards.Length; i++)
        {
            copiesMap.TryGetValue(i, out var copies);
            sum += copies + originalCopies;
        }

        return sum;
    }
}