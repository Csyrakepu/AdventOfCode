
/*
using AdventOfCode2022;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023;

class Day5Cope
{
    public static long Part1()
    {
        string source = Source.GetEntireSource(5);

        var seeds = source.Split('\n')[0].Split(" ")[1..].Select(number => new Seed(long.Parse(number))).ToList();
        string[] mapDeclarations = source.Split("\r\n\r\n")[1..];


        List<List<long>> seedSoilMap = mapDeclarations[0].Split("\r\n")[1..].Select(line => line.Split(' ').Select(number => long.Parse(number)).ToList()).ToList();
        List<List<long>> soilFertMap = mapDeclarations[1].Split("\r\n")[1..].Select(line => line.Split(' ').Select(number => long.Parse(number)).ToList()).ToList();
        List<List<long>> fertWaterMap = mapDeclarations[2].Split("\r\n")[1..].Select(line => line.Split(' ').Select(number => long.Parse(number)).ToList()).ToList();
        List<List<long>> waterLightMap = mapDeclarations[3].Split("\r\n")[1..].Select(line => line.Split(' ').Select(number => long.Parse(number)).ToList()).ToList();
        List<List<long>> lightTempMap = mapDeclarations[4].Split("\r\n")[1..].Select(line => line.Split(' ').Select(number => long.Parse(number)).ToList()).ToList();
        List<List<long>> tempHumidMap = mapDeclarations[5].Split("\r\n")[1..].Select(line => line.Split(' ').Select(number => long.Parse(number)).ToList()).ToList();
        List<List<long>> humidLocMap = mapDeclarations[6].Split("\r\n")[1..].Select(line => line.Split(' ').Select(number => long.Parse(number)).ToList()).ToList();

        var maps = new List<List<List<long>>>
        {
            seedSoilMap,
            soilFertMap,
            fertWaterMap,
            waterLightMap,
            lightTempMap,
            tempHumidMap,
            humidLocMap
        };

        long lowestLocation = seeds.Min(seed => seed.GetLocation(maps));

        return lowestLocation;
    }

    public static int Part2()
    {
        return 0;
    }
}

class Seed
{
    public long seed { get; set; }
    public long soil { get; set; }
    public long fertilizer { get; set; }
    public long water {  get; set; }
    public long light { get; set; }
    public long temperature { get; set; }
    public long humidity { get; set; }
    public long location { get; set; }


    public Seed(long seed)
    {
        this.seed = seed;
    }

    public long Calculate(long input, List<List<long>> map)
    {
        long result = -1;
        foreach (List<long> rules in map)
        {
            long destinationStart = rules[0];
            long sourceStart = rules[1];
            long range = rules[2];

            if ( !(input > sourceStart && input < sourceStart + range)) { continue; }

            long mapFactor = destinationStart - sourceStart;
            result = input + mapFactor;
            break;
        }
        return result;
    }

    public void CalculateAll(List<List<List<long>>> maps)
    {
        var soilMap = maps[0];
        var fertMap = maps[1];
        var waterMap = maps[2];
        var lightMap = maps[3];
        var tempMap = maps[4];
        var humidMap = maps[5];
        var locationMap = maps[6];

        soil = Calculate(seed, soilMap);
        fertilizer = Calculate(soil, fertMap);
        water = Calculate(fertilizer, waterMap);
        light = Calculate(water, lightMap);
        temperature = Calculate(light, tempMap);
        humidity = Calculate(temperature, humidMap);
        location = Calculate(humidity, locationMap);
    }

    public long GetLocation(List<List<List<long>>> maps)
    {
        CalculateAll(maps);
        return location;
    }

}
*/