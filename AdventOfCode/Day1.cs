namespace AdventOfCode2022;

class Day1
{
    public static int Part1()
    {
        string text = Source.GetEntireSource(1);
        string[] doubleNewLine = { "\r\n\r\n" };
        string[] newLine = { "\r\n" };

        int highestElf = 0;

        string[] separated = text.Split(doubleNewLine, StringSplitOptions.None);

        foreach (string elf in separated)
        {
            int currentElf = 0;
            string[] calories = elf.Split(newLine, StringSplitOptions.None);
            foreach (string cal in calories)
            {
                int calorieNum = Convert.ToInt32(cal);
                currentElf += calorieNum;
            }

            if (currentElf > highestElf)
            {
                highestElf = currentElf;
            }
        }
        return highestElf;
    }



    public static int Part2()
    {

        string text = Source.GetEntireSource(1);
        int[] top3Elf = new int[3];

        string[] doubleNewLine = { "\r\n\r\n" };
        string[] newLine = { "\r\n" };

        string[] separated = text.Split(doubleNewLine, StringSplitOptions.None);

        foreach (string elf in separated)
        {
            int currentElf = 0;
            string[] calories = elf.Split(newLine, StringSplitOptions.None);
            foreach (string cal in calories)
            {
                int calorieNum = Convert.ToInt32(cal);
                currentElf += calorieNum;
            }

            Array.Sort(top3Elf);
            if (top3Elf.Length < 3)
            {
                top3Elf.Append(currentElf);
            }
            if (top3Elf[0] < currentElf)
            {
                top3Elf[0] = currentElf;
            }
        }
        int top3Sum = top3Elf.Sum();
        return top3Sum;
    }
}
