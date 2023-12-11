namespace AdventOfCode2023;
class Day9
{
    public static int Part1()
    {
        string[] lines = Source.GetSourceLines(9);        

        var sequences = new List<Sequence>();
        foreach (string line in lines)
        {
            int[] numbers = line.Split(' ').Select(int.Parse).ToArray();
            sequences.Add(new Sequence(numbers));
        }
        return sequences.Sum(sequence => sequence.GetNext());
    }

    public static int Part2()
    {
        string[] lines = Source.GetSourceLines(9);

        var sequences = new List<Sequence>();
        foreach (string line in lines)
        {
            int[] numbers = line.Split(' ').Select(int.Parse).ToArray();
            sequences.Add(new Sequence(numbers));
        }
        return sequences.Sum(sequence => sequence.GetPrevious());
    }
}

class Sequence
{
    public List<int[]> lists;
    int initialLength;

    public Sequence(int[] initialSequence)
    {
        lists = new List<int[]> {initialSequence };
        initialLength = initialSequence.Length;
        FillSequences();
    }

    void FillSequences()
    {
        bool done = false;
        while (!done)
        {
            int[] currentArray = new int[lists[^1].Length - 1];
            for (int i = 1; i < lists[^1].Length; i++)
            {
                currentArray[i - 1] = lists[^1][i] - lists[^1][i - 1];
            }
            lists.Add(currentArray);
            done = lists[^1].All(n => n == 0);
        }               
    }

    public int GetNext()
    {
        for (int i = lists.Count-1; i > 0; i--)
        {
            int item = lists[i][^1] + lists[i - 1][^1];
            lists[i-1] = lists[i].Append(item).ToArray();
        }
        return lists[0][^1];        
    }

    public int GetPrevious()
    {
        for (int i = lists.Count - 1; i > 0; i--)
        {
            int item = lists[i - 1][0] - lists[i][0];

            List<int> copy = lists[i-1].ToList();
            copy.Insert(0, item);
            lists[i - 1] = copy.ToArray();
        }
        return lists[0][0];
    }

    public override string ToString()
    {
        return string.Join(" ", lists[0]);
    }
}
