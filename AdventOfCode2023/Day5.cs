using AdventOfCode2022;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023;

class Day5
{
    public static long Part1()
    {
        string source = Source.GetEntireSource(5);
        string[] parts = source.Split("\r\n\r\n");
        
        return 0;
    }

    public static long Part2()
    {
        return 0;
    }

    static long CalculateSeedLocation(long seed, string[] parts)
    {

        foreach (string part in parts) // végigmegy az átalakításokon
        {
            var lines = part.Split("\n\r")[1..];
            foreach (string line in lines) // próbál keresni egy érvényes sort az átalakításban
            {
                int[] numbers = line.Split(' ').Select(int.Parse).ToArray();
                
            }
        }
        return 0;
    }


}