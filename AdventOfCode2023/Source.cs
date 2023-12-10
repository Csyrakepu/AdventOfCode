namespace AdventOfCode2023;

class Source
{
    public static string GetEntireSource(int dayNumber, bool sample = false)
    {
        string day = dayNumber.ToString();
        string path = (sample) ? $"../../../../sourceSamples/2023/day{day}.txt" : $"../../../../sources/2023/day{day}.txt";
        string file = File.ReadAllText(path);
        return file;
    }

    public static string[] GetSourceLines(int dayNumber, bool sample = false)
    {
        string file = GetEntireSource(dayNumber, sample);
        return file.Split('\n');
    }
}