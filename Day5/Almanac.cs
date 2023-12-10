namespace AdventOfCode.Day5;

public record Almanac(
    Category SeedToSoil,
    Category SoilToFertilizer,
    Category FertilizerToWater,
    Category WaterToLight,
    Category LightToTemperature,
    Category TemperatureToHumidity,
    Category HumidityToLocation)
{
    public MapItem[] GetMap(string category)
    {
        return category switch
        {
            Categories.SeedToSoil => SeedToSoil.Map,
            Categories.SoilToFertilizer => SoilToFertilizer.Map,
            Categories.FertilizerToWater => FertilizerToWater.Map,
            Categories.WaterToLight => WaterToLight.Map,
            Categories.LightToTemperature => LightToTemperature.Map,
            Categories.TemperatureToHumidity => TemperatureToHumidity.Map,
            Categories.HumidityToLocation => HumidityToLocation.Map,
            _ => throw new ArgumentOutOfRangeException(nameof(category), category, null)
        };
    }

    public Category GetCategory(string categoryName)
    {
        return categoryName switch
        {
            Categories.SeedToSoil => SeedToSoil,
            Categories.SoilToFertilizer => SoilToFertilizer,
            Categories.FertilizerToWater => FertilizerToWater,
            Categories.WaterToLight => WaterToLight,
            Categories.LightToTemperature => LightToTemperature,
            Categories.TemperatureToHumidity => TemperatureToHumidity,
            Categories.HumidityToLocation => HumidityToLocation,
            _ => throw new ArgumentOutOfRangeException(nameof(categoryName), categoryName, null)
        };
    }

    public long GetNextCategoryIndex(string categoryName, long categoryIndex)
    {
        var category = GetCategory(categoryName);
        var mapItem = category.Map
            .FirstOrDefault(x => categoryIndex >= x.SourceRangeStart
                                 && x.SourceRangeStart + x.RangeLength > categoryIndex);
        if (mapItem != null)
        {
            return categoryIndex + (mapItem.DestinationRangeStart - mapItem.SourceRangeStart);
        }

        return categoryIndex;
    }
}