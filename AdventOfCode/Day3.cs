namespace AdventOfCode2022;

class Day3
{
    public static int Part1()
    {
        string[] lines = Source.GetSourceLines(3);

        int sum = 0;
        foreach (string line in lines)
        {

            string first = line[..(line.Length / 2)];
            string second = line[(line.Length / 2)..];

            char common = CommonLetter(first, second);
            int charValue = ConvertCharToValue(common);

            sum += charValue;
        }
        return sum;
    }



    public static int Part2()
    {

        string[] lines = Source.GetSourceLines(3);
        List<string> group = new List<string>();

        char common;
        int sum = 0;
        foreach (string line in lines)
        {
            group.Add(line);

            if (group.Count == 3)
            {
                common = CommonLetter(group.ToArray());
                sum += ConvertCharToValue(common);
                group.Clear();
            }


        }

        return sum;

    }

    static char CommonLetter(string a, string b)
    {
        char common = '#';
        foreach (char charA in a)
        {
            foreach (char charB in b)
            {
                if (charA == charB)
                {
                    common = charA;
                    break;
                }
            }
        }
        return common;
    }



    static char CommonLetter(string[] strings)
    {
        char[] commonLetters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        for (int i = 0; i < commonLetters.Length; i++)
        {
            foreach (string word in strings)
            {
                if (!word.Contains(commonLetters[i]))
                {
                    commonLetters[i] = '#';
                }
            }
        }

        foreach (char letter in commonLetters)
        {
            if (letter != '#')
            {
                return letter;
            }
        }
        return '#';
    }


    static int ConvertCharToValue(char searchedLetter)
    {
        char[] letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        int charValue = Array.IndexOf(letters, searchedLetter) + 1;
        return charValue;
    }
}
