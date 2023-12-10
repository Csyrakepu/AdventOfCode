namespace AdventOfCode2023;

class Write
{

    public static void Value<T>(T input)
    {
        Console.WriteLine(input);
    }

    public static void Multiple<T>(T first, T second)
    {
        Console.WriteLine($"{first} {second}");
    }

    public static void Enumerable<T>(IEnumerable<T> input)
    {
        if (input.Count() == 0) { Console.WriteLine("No items"); return; }

        foreach (T element in input)
        {
            Console.WriteLine(element);
        }        
    }

    public static void Enumerable2<T>(IEnumerable<IEnumerable<T>> input)
    {
        if (input.Count() == 0) { Console.WriteLine("No items"); return; }

        foreach (IEnumerable<T> layer2 in input)
        {
            foreach (T element in layer2)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }

    public static void Enumerable3<T>(IEnumerable<IEnumerable<IEnumerable<T>>> input)
    {
        if (input.Count() == 0) { Console.WriteLine("No items"); return; }

        foreach (IEnumerable<IEnumerable<T>> layer2 in input)
        {
            foreach (IEnumerable<T> layer3 in layer2)
            {
                foreach(T element in layer3)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n--------\n");
        }

    }

    public static void Enumerable<T>(IEnumerable<T> input, string separator)
    {
        if (input.Count() == 0) { Console.WriteLine("No items"); return; }

        foreach (T element in input)
        {
            Console.Write(element);
            Console.Write(separator);
        }
        Console.WriteLine();
    }
}