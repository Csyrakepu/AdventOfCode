namespace AdventOfCode2022;

class Day5
{
    public static string Part1()
    {
        string inputText = Source.GetEntireSource(5);
        string[] inputParts = inputText.Split("\r\n\r\n");

        string stacksInput = inputParts[0];
        string[] commands = inputParts[1].Split("\r\n");

        Stack[] stacks = ConvertStacks(stacksInput);
        
        foreach (string command in commands)
        {
            int[] commandParameters = ConvertCommand(command);

            int count = commandParameters[0];
            int sourceId = commandParameters[1];
            int targetId = commandParameters[2];

            Stack sourceStack = FindObjectOfId(sourceId, stacks);
            Stack targetStack = FindObjectOfId(targetId, stacks);

            Stack.MoveCrates(count, sourceStack, targetStack);
        }

        string output = GetTopElements(stacks);
        return output;
    }


    public static string Part2()
    {
        string inputText = Source.GetEntireSource(5);
        string[] inputParts = inputText.Split("\r\n\r\n");

        string stacksInput = inputParts[0];
        string[] commands = inputParts[1].Split("\r\n");

        Stack[] stacks = ConvertStacks(stacksInput);

        foreach (string command in commands)
        {
            int[] commandParameters = ConvertCommand(command);

            int count = commandParameters[0];
            int sourceId = commandParameters[1];
            int targetId = commandParameters[2];

            Stack sourceStack = FindObjectOfId(sourceId, stacks);
            Stack targetStack = FindObjectOfId(targetId, stacks);

            Stack.MoveCratesAtOnce(count, sourceStack, targetStack);
        }

        string output = GetTopElements(stacks);
        return output;
    }


    static int[] ConvertCommand(string command)
    {
        List<int> result = new List<int>();
        string[] words = command.Split(" ");

        foreach (string word in words)
        {
            int number;
            bool success = int.TryParse(word, out number);

            if (success)
            {
                result.Add(number);
            }
            else
            {
                continue;
            }

        }
        
        return result.ToArray();

    }

    static Stack[] ConvertStacks(string unformattedInput)
    {
        string[] stringStacks = ConvertStacksToStringArray(unformattedInput);
        List<Stack> result = new List<Stack>();

        
        foreach (string stack in stringStacks)
        {
            char lastCharacter = stack[^1];
            int stackId = Int16.Parse(lastCharacter.ToString());

            string pureStack = stack[..^1];

            Stack currentStack = new Stack(stackId, pureStack);
            result.Add(currentStack);
        }
        return result.ToArray();
    }

    static string[] ConvertStacksToStringArray(string input)
    {
        string[] stacks = new string[9];
        string[] rows = input.Split("\r\n");

        foreach (string row in rows)
        {
            for (int columnIndex = 0; columnIndex < row.Length; columnIndex++)
            {
                char c = row[columnIndex];
                if (c == ' ' || c == ']' || c == '[')
                {
                    continue;
                }

                int stackId = GetCoulumn(columnIndex);
                stacks[stackId] += c;
            }
        }
        return stacks;
    }

    static int GetCoulumn(int charIndex)
    {
        int column = (charIndex - 1) / 4;
        return column;
    }


    static Stack FindObjectOfId(int id, Stack[] stacks)
    {
        foreach (Stack stack in stacks)
        {
            if (stack.id == id)
            {
                return stack;
            }
        }

        Console.WriteLine("Stack not found");
        return new Stack(0, "");
    }

    static string GetTopElements(Stack[] stacks)
    {
        string output = "";
        foreach(Stack stack in stacks)
        {
            char topCrate = stack.crates[0];
            output += topCrate;
        }

        return output;
    }
}



class Stack
{
    public int id;
    public string crates;

    public Stack(int id, string crates)
    {
        this.id = id;
        this.crates = crates;
    }


    public static void MoveCrates(int count, Stack source, Stack target)
    {       
        for (int i = 0; i < count; i++)
        {                        
            target.crates = source.crates[0] + target.crates;
            source.crates = source.crates[1..];
        }
    }

    public static void MoveCratesAtOnce(int count, Stack source, Stack target)
    {
        target.crates = source.crates[..count] + target.crates;
        source.crates = source.crates[count..];
    }

    public override string ToString()
    {
        return crates;
    }
}
