using System.Text;

namespace AdventOfCode.Day3;

public class Solver
{
    public static async Task<int> GetAnswer1()
    {
        var engine = await EngineReader.GetEngine();
        return engine.GetParts().Sum(x => x.number.Value);
    }
    
    public static async Task<int> GetAnswer2()
    {
        var engine = await EngineReader.GetEngine();
        return engine.GetGears().Sum(x => x.number1 * x.number2);
    }
}