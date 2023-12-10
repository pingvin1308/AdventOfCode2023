namespace AdventOfCode.Day5;

public static class Solver
{
    public static async Task<long> GetAnswer1()
    {
        var (seeds, almanac) = await AlmanacReader.GetValues();
        var conversions = new Dictionary<long, List<long>>();
        var locations = new HashSet<long>();

        foreach (var seed in seeds)
        {
            conversions.Add(seed, new List<long>());

            foreach (var category in Categories.All)
            {
                var categoryIndex = almanac.GetNextCategoryIndex(category, conversions[seed].LastOrDefault(seed));
                conversions[seed].Add(categoryIndex);

                if (category == Categories.HumidityToLocation)
                {
                    locations.Add(categoryIndex);
                }
            }
        }

        return locations.Min();
    }

    public static async Task<long> GetAnswer2()
    {
        var (seeds, almanac) = await AlmanacReader.GetValues();
        var conversions = new Dictionary<long, List<long>>();
        var locations = new HashSet<long>();

        for (var i = 0; i < seeds.Length / 2; i += 2)
        {
            var seedStart = seeds[i];
            var seedCount = 1; //seeds[i + 1];

            for (var seed = seedStart; seed < (seedStart + seedCount); seed++)
            {
                conversions.Add(seed, new List<long>());

                foreach (var category in Categories.All)
                {
                    var categoryIndex = almanac.GetNextCategoryIndex(category, conversions[seed].LastOrDefault(seed));
                    conversions[seed].Add(categoryIndex);

                    if (category == Categories.HumidityToLocation)
                    {
                        locations.Add(categoryIndex);
                    }
                }
            }
        }

        return locations.Min();
    }
}