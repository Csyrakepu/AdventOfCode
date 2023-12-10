namespace AdventOfCode2023;

class Day6
{
    public static long Part1()
    {
        string[] lines = Source.GetSourceLines(6);

        int[] times = lines[0].Split(' ')[1..].Where(word => word != "").Select(int.Parse).ToArray();
        int[] distances = lines[1].Split(' ')[1..].Where(word => word != "").Select(int.Parse).ToArray();

        long result = 1;
        for (int round = 0; round < times.Length; round++)
        {          
            result *= CountRecords(times[round], distances[round]);
        }
        return result;
    }

    public static long Part2()
    {
        string[] lines = Source.GetSourceLines(6);

        string[] timeDeclarations = lines[0].Split(" ")[1..];
        long time = long.Parse(string.Join(string.Empty, timeDeclarations));

        string[] distanceDeclarations = lines[1].Split(" ")[1..];
        long distance = long.Parse(string.Join(string.Empty, distanceDeclarations));

        return CountRecords(time, distance);
    }

    static long CountRecords(long maxTime, long record)
    {
        long winnerOptions = 0;
        for (long velocity = 0; velocity <= maxTime; velocity++) // goes through speeds
        {
            long remainingTime = maxTime - velocity;
            long distanceTravelled = remainingTime * velocity;
            if (distanceTravelled > record)
            {
                winnerOptions++;
            }
        }
        return winnerOptions;
    }
}
