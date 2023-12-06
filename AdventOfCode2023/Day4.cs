using AdventOfCode2022;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023;

class Day4
{
    public static int Part1()
    {
        string[] games = Source.GetSourceLines(4);

        int sum = 0;
        foreach (string game in games)
        {
            string numbers = game.Split(":")[1];
            int[] winningNumbers = numbers.Split('|')[0].Split(' ').Where(n => n != "").Select(int.Parse).ToArray();
            int[] playerNumbers = numbers.Split('|')[1].Split(' ').Where(n => n != "").Select(int.Parse).ToArray();

            int numberOfCommonNumbers = winningNumbers.Count(n => playerNumbers.Contains(n));
            sum += CalculateGameScore(numberOfCommonNumbers);
        }
        return sum;
    }

    public static int Part2()
    {
        return 0;
    }

    static int CalculateGameScore(int commonNumbers)
    {
        if (commonNumbers == 0) { return 0; }

        int result = 1;
        while (commonNumbers > 1)
        {
            result = result * 2;
            commonNumbers--;
        }
        return result;
    }

}
