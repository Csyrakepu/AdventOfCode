namespace AdventOfCode2023;
class Day8
{
    public static int Part1()
    {
        string source = Source.GetEntireSource(8);

        char[] instructions = source.Split("\r\n\r\n")[0].ToCharArray();
        string[] maps = source.Split("\r\n\r\n")[1].Split("\r\n");


        string current = "AAA";
        for (int i = 0; ; i++)
        {
            current = FindRoute(current, instructions[i % instructions.Length], maps);
            if (current == "ZZZ")
            {
                return i + 1;
            }
        }
    }

    public static long Part2()
    {
        string source = Source.GetEntireSource(8);
        string[] maps = source.Split("\r\n\r\n")[1].Split("\r\n");
        List<GhostPath> routes = maps.Where(map => map[2] == 'A').Select(map => new GhostPath(map[..3], source)).ToList();
        routes.ForEach(route => route.FindFirstFound());

        int[] firstFoundValues = routes.Select(route => route.foundFirstIndex).ToArray();
        return GetArrayLCM(firstFoundValues);
    }

    static string FindRoute(string left, char direction, string[] maps)
    {
        string chosenLine = maps.First(line => line.StartsWith(left));

        switch (direction)
        {
            case 'L':
                return chosenLine[7..10];
            case 'R':
                return chosenLine[12..15];
            default:
                Console.WriteLine("Not found");
                return chosenLine;
        }
    }

    static long GetArrayLCM(int[] routes)
    {
       long output = routes[0];

        for (int i = 1; i < routes.Length; i++)
        {
            output = LCM(output, routes[i]);
        }
        return output;
    }

    static long LCM(long aStart, long bStart)
    {
        (long a, long b) = (aStart, bStart);

        while (a != b)
        {
            if (a < b) { a = a + aStart; }
            else { b = b + bStart; }
        }
        return a;
    }
}

class GhostPath
{
    public string current;
    char[] instructions;
    string[] maps;
    public int foundFirstIndex;


    public GhostPath(string startingPoint, string source)
    {
        current = startingPoint;
        instructions = source.Split("\r\n\r\n")[0].ToCharArray();
        maps = source.Split("\r\n\r\n")[1].Split("\r\n");

    }

    public string FindRoute(string left, char direction, string[] maps)
    {
        string chosenLine = maps.First(line => line.StartsWith(left));

        switch (direction)
        {
            case 'L':
                return chosenLine[7..10];
            case 'R':
                return chosenLine[12..15];
            default:
                Console.WriteLine("Not found");
                return chosenLine;
        }
    }

    public void FindFirstFound()
    {
        for (int i = 0; ; i++)
        {
            current = FindRoute(current, instructions[i % instructions.Length], maps);
            if (current[^1] == 'Z')
            {
                foundFirstIndex = i + 1;
                break;
            }
        }
    }

    public override string ToString()
    {
        return $"{current}";
    }
}