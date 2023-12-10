namespace AdventOfCode2022;

class Write
{
    public static void AllELements<T>(T[] input)
    {
        if (input.Length == 0)
        {
            Console.WriteLine("No items");
            return;
        }

        foreach (T element in input)
        {
            Console.WriteLine(element);
        }
    }

    public static void AllELements(string input)
    {
        if (input.Length == 0)
        {
            Console.WriteLine("No items");
            return;
        }

        foreach (char c in input)
        {
            Console.WriteLine(c);
        }
    }




    public static void ElementsInLine<T>(T[] input)
    {
        if (input.Length == 0)
        {
            Console.WriteLine("No items");
            return;
        }

        foreach (T element in input)
        {
            Console.Write($"{element} ");
        }
        Console.WriteLine();
    }



    public static void ElementsInLine(string input)
    {
        if (input.Length == 0)
        {
            Console.WriteLine("No items");
            return;
        }


        foreach (char c in input)
        {
            Console.Write($"{c} ");
        }
        Console.WriteLine();
    }
}