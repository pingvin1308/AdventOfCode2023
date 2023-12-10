namespace AdventOfCode.Day5;

public static class Categories
{
    public const string SeedToSoil = "seed-to-soil map:";
    public const string SoilToFertilizer = "soil-to-fertilizer map:";
    public const string FertilizerToWater = "fertilizer-to-water map:";
    public const string WaterToLight = "water-to-light map:";
    public const string LightToTemperature = "light-to-temperature map:";
    public const string TemperatureToHumidity = "temperature-to-humidity map:";
    public const string HumidityToLocation = "humidity-to-location map:";

    public static readonly string[] All =
    {
        SeedToSoil,
        SoilToFertilizer,
        FertilizerToWater,
        WaterToLight,
        LightToTemperature,
        TemperatureToHumidity,
        HumidityToLocation
    };
}