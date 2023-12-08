namespace AdventOfCode2023;

class Source
{
    public static string GetEntireSource(int dayNumber)
    {
        string day = Convert.ToString(dayNumber);
        string file = File.ReadAllText($"../../../../sources/2023/day{day}.txt");
        return file;
    }

    public static string[] GetSourceLines(int dayNumber)
    {
        string day = Convert.ToString(dayNumber);
        string file = File.ReadAllText($"../../../../sources/2023/day{day}.txt");
        string[] lines = file.Split('\n');
        return lines;
    }
}