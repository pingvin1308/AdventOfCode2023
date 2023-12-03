namespace AdventOfCode.Day1;

public static class CalibrationValues
{
    public static async Task<string[]> GetValues()
    {
        return await File.ReadAllLinesAsync("Day1/input.txt");
    }
}