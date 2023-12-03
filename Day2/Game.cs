namespace AdventOfCode.Day2;

public record Game(int GameNumber, Set[] Sets)
{
    public bool CanPlay()
    {
        return Sets.All(x => x.CanPlay());
    }
}