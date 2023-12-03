namespace AdventOfCode.Day1;

public static class Solver
{
    public static async Task<int> GetAnswer()
    {
        var calibrationValues = await CalibrationValues.GetValues();
        var finalNumbers = new List<(string CalibrationValue, int FinalNumber)>();

        var digits = new Dictionary<string, int>
        {
            { "one", 1 },
            { "1", 1 },
            { "two", 2 },
            { "2", 2 },
            { "three", 3 },
            { "3", 3 },
            { "four", 4 },
            { "4", 4 },
            { "five", 5 },
            { "5", 5 },
            { "six", 6 },
            { "6", 6 },
            { "seven", 7 },
            { "7", 7 },
            { "eight", 8 },
            { "8", 8 },
            { "nine", 9 },
            { "9", 9 },
        };

        foreach (var calibrationValue in calibrationValues)
        {
            var numbersWithIndexes = new List<(int Value, int IndexOfNumber)>();

            foreach (var digit in digits)
            {
                var indexOfNumber = calibrationValue.IndexOf(digit.Key, StringComparison.Ordinal);
                if (indexOfNumber == -1) continue;
                numbersWithIndexes.Add((digit.Value, indexOfNumber));
            }

            foreach (var digit in digits)
            {
                var indexOfNumber = calibrationValue.LastIndexOf(digit.Key, StringComparison.Ordinal);
                if (indexOfNumber == -1) continue;
                numbersWithIndexes.Add((digit.Value, indexOfNumber));
            }

            numbersWithIndexes.Sort((a, b) => a.IndexOfNumber.CompareTo(b.IndexOfNumber));

            if (numbersWithIndexes.Count > 0)
            {
                var finalNumber = int.Parse($"{numbersWithIndexes[0].Value}{numbersWithIndexes[^1].Value}");
                finalNumbers.Add((calibrationValue, finalNumber));
            }
        }

        foreach (var finalNumber in finalNumbers)
        {
            Console.Write(finalNumber);
            Console.WriteLine();
        }

        return finalNumbers.Sum(x => x.FinalNumber);
    }
}