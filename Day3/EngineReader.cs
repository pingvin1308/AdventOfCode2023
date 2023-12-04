using System.Text;

namespace AdventOfCode.Day3;

public static class EngineReader
{
    public static async Task<Engine> GetEngine()
    {
        await using var stream = File.OpenRead("Day3/input.txt");
        using var s = new StreamReader(stream);

        var lineNumber = 0;
        var digits = new HashSet<EngineDigit>();
        StringBuilder numberStr = new StringBuilder();

        var numbers = new HashSet<EngineNumber>();
        var symbols = new HashSet<EngineSymbol>();
        var width = 0;

        while (!s.EndOfStream)
        {
            var line = await s.ReadLineAsync() ?? string.Empty;
            width = line.Length;
            for (var i = 0; i < line.Length; i++)
            {
                var c = line[i];

                if (char.IsDigit(c))
                {
                    digits.Add(new EngineDigit(c, (i, lineNumber)));
                    numberStr.Append(c);
                }
                else
                {
                    if (numberStr.Length > 0)
                    {
                        numbers.Add(new EngineNumber(
                            Value: int.Parse(numberStr.ToString()),
                            Digits: digits.ToArray()));
                        numberStr.Clear();
                        digits.Clear();
                    }

                    if (c != '.')
                    {
                        symbols.Add(new EngineSymbol(c, (i, lineNumber)));
                    }
                }
            }

            lineNumber++;
        }

        return new Engine(
            Numbers: numbers.ToArray(),
            Symbols: symbols.ToArray(),
            Width: width,
            Height: lineNumber + 1);
    }
}

public record Engine(EngineNumber[] Numbers, EngineSymbol[] Symbols, int Width, int Height)
{
    public (EngineSymbol symbol, EngineNumber number)[] GetParts()
    {
        var result = new HashSet<(EngineSymbol symbol, EngineNumber number)>();
        foreach (var symbol in Symbols)
        {
            var (x, y) = symbol.Coordinates;
            var coordsAroundSymbol = new[]
            {
                (x, Math.Max(0, y - 1)),
                (Math.Max(0, x - 1), Math.Max(0, y - 1)),
                (Math.Min(Width, x + 1), Math.Max(0, y - 1)),
                (x, Math.Min(Height, y + 1)),
                (Math.Max(0, x - 1), Math.Min(Height, y + 1)),
                (Math.Min(Width, x + 1), Math.Min(Height, y + 1)),
                (Math.Max(0, x - 1), y),
                (Math.Min(Width, x + 1), y),
            };

            foreach (var coordAroundSymbol in coordsAroundSymbol)
            {
                var number = Numbers.FirstOrDefault(n => n.Digits.Any(y => y.Coordinates == coordAroundSymbol));
                if (number != null)
                {
                    result.Add((symbol, number));
                }
            }
        }

        return result.ToArray();
    }

    public (int number1, int number2)[] GetGears()
    {
        return Array.Empty<(int, int)>();
    }
}

public record EngineNumber(int Value, EngineDigit[] Digits);

public record EngineDigit(char Digit, (int, int) Coordinates);

public record EngineSymbol(char Symbol, (int, int) Coordinates);