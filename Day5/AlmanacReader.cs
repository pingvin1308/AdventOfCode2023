namespace AdventOfCode.Day5;

public static class AlmanacReader
{
    public static async Task<(long[] seeds, Almanac almanac)> GetValues()
    {
        var input = await File.ReadAllLinesAsync("Day5/input.txt");
        var categories = new Queue<string>(Categories.All);
        var currentCategory = categories.Dequeue();
        var almanacMaps = new Dictionary<string, List<MapItem>>();

        foreach (var line in input[2..])
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                currentCategory = categories.Dequeue();
            }
            else
            {
                if (line == currentCategory)
                {
                    almanacMaps.Add(line, new List<MapItem>());
                }
                else
                {
                    var numbers = line
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(long.Parse)
                        .ToArray();
                    var map = new MapItem(
                        DestinationRangeStart: numbers[0],
                        SourceRangeStart: numbers[1],
                        RangeLength: numbers[2]);
                    almanacMaps[currentCategory].Add(map);
                }
            }
        }

        var seeds = input[0]
            .Split(':')[1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToArray();

        var almanac = new Almanac(
            SeedToSoil: new Category(Categories.SeedToSoil, almanacMaps[Categories.SeedToSoil].ToArray()),
            SoilToFertilizer: new Category(Categories.SoilToFertilizer, almanacMaps[Categories.SoilToFertilizer].ToArray()),
            FertilizerToWater: new Category(Categories.FertilizerToWater, almanacMaps[Categories.FertilizerToWater].ToArray()),
            WaterToLight: new Category(Categories.WaterToLight, almanacMaps[Categories.WaterToLight].ToArray()),
            LightToTemperature: new Category(Categories.LightToTemperature, almanacMaps[Categories.LightToTemperature].ToArray()),
            TemperatureToHumidity: new Category(Categories.TemperatureToHumidity, almanacMaps[Categories.TemperatureToHumidity].ToArray()),
            HumidityToLocation: new Category(Categories.HumidityToLocation, almanacMaps[Categories.HumidityToLocation].ToArray())
        );

        return (seeds, almanac);
    }
}