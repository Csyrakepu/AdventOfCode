﻿namespace AdventOfCode2023;

class Day4
{
    public static int Part1()
    {
        string[] games = Source.GetSourceLines(4);
        int sum = 0;
        foreach (string game in games)
        {
            int numberOfCommonNumbers = GetNumberOfCommons(game);
            sum += CalculateGameScore(numberOfCommonNumbers);
        }
        return sum;
    }

    public static int Part2()
    {
        string[] games = Source.GetSourceLines(4);
        int[] gameCounts = new int[games.Length].Select(_ => 1).ToArray();

        for (int currentId = 0; currentId < games.Length; currentId++)
        {
            int result = GetNumberOfCommons(games[currentId]);
            for (int receiveId = currentId + 1; receiveId < currentId + result + 1; receiveId++)
            {
                gameCounts[receiveId] += gameCounts[currentId];
            }
        }
        return gameCounts.Sum();
    }

    static int GetNumberOfCommons(string game)
    {
        string numbers = game.Split(":")[1];
        int[] winningNumbers = numbers.Split('|')[0].Split(' ').Where(n => n != "").Select(int.Parse).ToArray();
        int[] playerNumbers = numbers.Split('|')[1].Split(' ').Where(n => n != "").Select(int.Parse).ToArray();

        return winningNumbers.Count(n => playerNumbers.Contains(n));
    }

    static int CalculateGameScore(int commonNumbers)
    {
        if (commonNumbers == 0) { return 0; }
        return (int)Math.Pow(2, commonNumbers - 1);
    }
}
