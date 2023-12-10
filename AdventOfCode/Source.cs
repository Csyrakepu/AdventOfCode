namespace AdventOfCode2022;

class Source
{
    public static string GetEntireSource(int dayNumber)
    {
        string day = Convert.ToString(dayNumber);
        string file = File.ReadAllText($"../../../../sources/2022/day{day}.txt");
        return file;
    }

    public static string[] GetSourceLines(int dayNumber)
    {
        string day = Convert.ToString(dayNumber);
        string file = File.ReadAllText($"../../../../sources/2022/day{day}.txt");
        string[] lines = file.Split('\n');
        return lines;
    }
}