namespace AdventOfCode2022;

class Day4
{
    public static int Part1()
    {
        string[] lines = Source.GetSourceLines(4);

        int sum = 0;
        foreach (string line in lines)
        {

            int[] nums = ConvertNumbers(line);

            OverlapLevel overlap = Overlap(nums[0], nums[1], nums[2], nums[3]);
            if (overlap == OverlapLevel.Full)
            {
                sum++;
            }
        }


        return sum;
    }


    public static int Part2()
    {
        string[] lines = Source.GetSourceLines(4);
        int sum = 0;
        foreach (string line in lines)
        {
            int[] nums = ConvertNumbers(line);
            OverlapLevel overlap = Overlap(nums[0], nums[1], nums[2], nums[3]);
            if (overlap == OverlapLevel.Full || overlap == OverlapLevel.Some)
            {
                sum++;
            }
        }

        return sum;
    }


    static int[] ConvertNumbers(string line)
    {
        string[] digits = line.Split(',', '-');
        List<int> numbers = new List<int>();

        foreach (string num in digits)
        {
            numbers.Add(Convert.ToInt16(num));
        }
        int[] numbersarray = numbers.ToArray();
        return numbersarray;

    }


    static bool IsInRange(int n, int min, int max)
    {
        return n >= min && n <= max;
    }


    static OverlapLevel Overlap(int firstStart, int firstEnd, int secondStart, int secondEnd)
    {

        bool someOverlap = false;
        bool fullOverlap = false;

        List<int> firstExclusives = new List<int>();
        List<int> secondExclusives = new List<int>();

        List<int> first = new List<int>();
        List<int> second = new List<int>();

        for (int i = 0; i < 100; i++)
        {
            if (i >= firstStart && i <= firstEnd)
            {
                first.Add(i);
            }

            if (i >= secondStart && i <= secondEnd)
            {
                second.Add(i);
            }
        }

        for (int i = 0; i < 100; i++)
        {
            if (first.Contains(i) && second.Contains(i))
            {
                someOverlap = true;
            }

            if (first.Contains(i) && !second.Contains(i))
            {
                firstExclusives.Add(i);
            }

            if (second.Contains(i) && !first.Contains(i))
            {
                secondExclusives.Add(i);
            }
        }

        if (firstExclusives.Count == 0 || secondExclusives.Count == 0)
        {
            fullOverlap = true;
        }


        if (fullOverlap) { return OverlapLevel.Full; }
        else if (someOverlap) { return OverlapLevel.Some; }
        else { return OverlapLevel.None; }

    }
}

enum OverlapLevel
{
    None,
    Some,
    Full
}
