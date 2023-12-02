using AdventOfCode2022;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

class Day2
{
    public static int Part1()
    {
        string[] lines = Source.GetSourceLines(2);

        int sum = 0;
        foreach (string line in lines)
        {
            List<Subset> subsets = CreateSubsets(line);
            int id = GetGameId(line);

            Game game = new Game(id, subsets);
            sum += game.GetScore();
        }
        
        return sum;
    }

    public static int Part2()
    {
        string[] lines = Source.GetSourceLines(2);

        int sum = 0;
        foreach (string line in lines)
        {
            List<Subset> subsets = CreateSubsets(line);
            int id = GetGameId(line);

            Game game = new Game(id, subsets);
            sum += game.GetPowerScore();
        }

        return sum;
    }

    static List<Subset> CreateSubsets(string line)
    {
        string declarations = line.Split(':')[1];
        List<string> subsetTexts = declarations.Split(';').ToList();

        List<Subset> subsets = new List<Subset>();

        foreach (string subsetText in subsetTexts)
        {
            List<string> colors = subsetText.Split(",").ToList();

            int redCount = GetColorCount(colors, "red");
            int greenCount = GetColorCount(colors, "green");
            int blueCount = GetColorCount(colors, "blue");

            Subset current = new Subset(redCount, greenCount, blueCount);
            subsets.Add(current);
        }       
        return subsets;
    }

    static int GetColorCount(List<string> colors, string color)
    {
        string? declaration = colors.Find(text => text.Contains(color));
        if (declaration == null) return 0;

        int result = int.Parse(declaration.Split(' ')[1]);
        return result;
    }

    static int GetGameId(string line)
    {
        string gameSpecifier = line.Split(':')[0];
        int gameNumber = int.Parse(gameSpecifier.Split(' ')[1]);

        return gameNumber;
    }

}

class Game
{
    public readonly int id;
    List<Subset> subsets = new();

    public Game(int id, List<Subset> subsets)
    {
        this.id = id;
        this.subsets = subsets;
    }

    public int GetScore()
    {
        bool isPossible = true;
        foreach (Subset subset in subsets)
        {
            if (!subset.IsPossible()) { isPossible = false; break; }
        }
        return isPossible ? id : 0;
    }

    public int GetPowerScore()
    {
        int minimumReds = 0;
        int minimumGreens = 0;
        int minimumBlues = 0;

        foreach (Subset subset in subsets)
        {
            minimumReds = Math.Max(subset.Red, minimumReds);
            minimumGreens = Math.Max(subset.Green, minimumGreens);
            minimumBlues = Math.Max(subset.Blue, minimumBlues);
        }

        return minimumReds * minimumGreens * minimumBlues;
    }
}

class Subset
{
    public readonly int redMax = 12;
    public readonly int greenMax = 13;
    public readonly int blueMax = 14;

    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }

    public Subset(int red, int green, int blue)
    {
        Red = red;
        Green = green;
        Blue = blue;
    }


    public bool IsPossible()
    {
        return Red <= redMax && Green <= greenMax && Blue <= blueMax;
    }
}
