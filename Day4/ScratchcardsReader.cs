namespace AdventOfCode.Day4;

public static class ScratchcardsReader
{
    public static async IAsyncEnumerable<Scratchcard> GetValues()
    {
        await using var stream = File.OpenRead("Day4/input.txt");
        using var streamReader = new StreamReader(stream);

        while (!streamReader.EndOfStream)
        {
            var line = await streamReader.ReadLineAsync() ?? string.Empty;
            var cardNumbers = line.Split(':')[1].Split('|');
            var winningNumbers = cardNumbers[0]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToHashSet();
            var numbers = cardNumbers[1]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            yield return new Scratchcard(
                WinningNumbers: winningNumbers,
                Numbers: numbers);
        }
    }
}