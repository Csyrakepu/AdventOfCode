using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2023;

class Day5
{
    public static long Part1()
    {
        string source = Source.GetEntireSource(5);

        long[] seeds = source.Split("\r\n")[0].Split(' ')[1..].Select(long.Parse).ToArray();
        string[] mapDeclarations = source.Split("\r\n\r\n")[1..];

        List<long> results = new List<long>();
        foreach (long seed  in seeds)
        {
            results.Add(GetSeedLocation(seed, mapDeclarations));
        }
        return results.Min();
    }

    public static long Part2()
    {
        Console.WriteLine("Start");
        string source = Source.GetEntireSource(5);
        string[] mapDeclarations = source.Split("\r\n\r\n")[1..];
        long[] seedRangeNumbers = source.Split("\r\n")[0].Split(' ')[1..].Select(long.Parse).ToArray();
        var pairs = GetPairs(seedRangeNumbers);

        long lowest = long.MaxValue;

        foreach (var pair in pairs)
        {
            foreach (long number in GenerateSeeds(pair.Item1, pair.Item2))
            {
                lowest = Math.Min(lowest, GetSeedLocation(number, mapDeclarations));
                
            }
        }
        return lowest;
    }

    static long GetSeedLocation(long seed, string[] mapDeclarations)
    {         
        foreach (string declaration in mapDeclarations)
        {
            string[] lines = declaration.Split("\r\n")[1..];
            foreach (string line in lines)
            {
                (long targetStart, long sourceStart, long range) = GetNumbersFromText(line);
                
                long mapAmount = targetStart - sourceStart;
                bool inRange = seed >= sourceStart && seed < sourceStart + range;
                
                if (inRange)
                {
                    seed += mapAmount;
                    break;
                }
                
            }
        }
        return seed;
    }

    static (long targetStart, long sourceStart, long range) GetNumbersFromText(string line)
    {
        long[] numbers = line.Split(' ').Select(long.Parse).ToArray();

        long targetStart = numbers[0];
        long sourceStart = numbers[1];
        long range = numbers[2];
        return (targetStart, sourceStart, range);
    }

    static IEnumerable<long> GenerateSeeds(long start, long count)
    {
        for (long i = start; i < start + count; i++)
        {
            yield return i;
        }
    }

    static List<(long start, long count)> GetPairs(long[] numbers)
    {
        var output = new List<(long start, long count)>();
        for (int i = 0; i < numbers.Length; i += 2)
        {
            output.Add((numbers[i], numbers[i + 1]));
        }
        return output;
    }
}