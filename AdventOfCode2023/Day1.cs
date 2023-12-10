namespace AdventOfCode2023;

class Day1
{
    public static int Part1()
    {
        string[] lines = Source.GetSourceLines(1);
        return lines.Sum(GetLineOutput);
    }

    public static int Part2()
    {
        string[] lines = Source.GetSourceLines(1);
        return lines.Sum(GetLineOutputWithWords);
    }


    public static int Test()
    {
        string line = "eightthreeseven2nnkvlzxkvhszfpqzhl37ddqvnxg";
        int output = GetLineOutputWithWords(line);
        return output;
    }

    static int GetLineOutput(string line)
    {
        string digits = "123456789";

        var numberList = new List<string>();
        foreach (char ch in line)
        {
            if (digits.Contains(ch))
            {
                numberList.Add(ch.ToString());
            }
        }
        string outputAsString = numberList[0] + numberList[^1];
        return int.Parse(outputAsString);
    }

    public static int GetLineOutputWithWords(string line)
    {
        var digitWords = new Dictionary<string, int>
        {
            {"one", 1 },
            {"two", 2 },
            {"three", 3 },
            {"four", 4 },
            {"five", 5 },
            {"six", 6 },
            {"seven", 7 },
            {"eight", 8 },
            {"nine", 9 },
        };
        var digits = "123456789";

        int first = -1;
        int last = -1;


        // first
        string buffer = "";
        bool firstFound = false;
        for (int i = 0; i < line.Length; i++)
        {
            if (firstFound) break;

            if (digits.Contains(line[i]))
            {
                first = int.Parse(line[i].ToString());
                firstFound = true;
                break;
            }

            buffer += line[i];
            foreach (KeyValuePair<string, int> word in digitWords)
            {
                if (buffer.Contains(word.Key))
                {
                    first = word.Value;
                    firstFound = true;
                    break;
                }
            }
        }

        // last
        buffer = "";
        bool lastFound = false;
        for (int i = line.Length - 1; i >= 0; i--)
        {
            if (lastFound) break;

            if (digits.Contains(line[i]))
            {
                last = int.Parse(line[i].ToString());
                lastFound = true;
                break;
            }

            buffer = line[i] + buffer;
            foreach (KeyValuePair<string, int> word in digitWords)
            {
                if (buffer.Contains(word.Key))
                {
                    last = word.Value;
                    lastFound = true;
                    break;
                }
            }
        }
        return first * 10 + last;
    }
}