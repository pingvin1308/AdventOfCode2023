namespace AdventOfCode.Day2;

public static class GameSets
{
    public static async IAsyncEnumerable<Game> GetValues()
    {
        var input = await File.ReadAllLinesAsync("Day2/input.txt");

        foreach (var row in input)
        {
            var gameStr = row.Split(':')[0];
            var gameNumber = int.Parse(gameStr.Split(' ')[1]);
            var setsStr = row.Split(':')[1].Split(';');

            var sets = GetSets(setsStr);

            yield return new Game(gameNumber, sets.ToArray());
        }
    }

    private static Set[] GetSets(string[] setsStr)
    {
        var sets = new List<Set>();
        foreach (var setStr in setsStr)
        {
            var cubes = setStr.Split(',');

            var cubeMap = new Dictionary<string, int>();
            foreach (var cube in cubes)
            {
                var cubeType = cube.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];
                var cubeCount = int.Parse(cube.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]);

                cubeMap[cubeType] = cubeCount;
            }

            cubeMap.TryGetValue("red", out var redCount);
            cubeMap.TryGetValue("blue", out var blueCount);
            cubeMap.TryGetValue("green", out var greenCount);

            sets.Add(new Set(redCount, greenCount, blueCount));
        }

        return sets.ToArray();
    }
}