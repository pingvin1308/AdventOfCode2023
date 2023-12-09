namespace AdventOfCode.Day4;

public record Scratchcard(HashSet<int> WinningNumbers, int[] Numbers)
{
    public int CalcPoints()
    {
        var result = Numbers.Where(number => WinningNumbers.Contains(number))
            .Aggregate(0, (current, _) => current == 0
                ? 1
                : current * 2);

        return result;
    }

    public int GetNextCopies()
    {
        var result = Numbers.Where(number => WinningNumbers.Contains(number));
        return result.Count();
    }
}