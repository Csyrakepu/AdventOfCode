namespace AdventOfCode2022;

class Day2
{
    public static int Part1()
    {
        string text = Source.GetEntireSource(2);
        string[] lines = text.Split('\n');

        int sum = 0;
        foreach (string line in lines)
        {
            int opp = ConvertMoveToInt(line.Split(" ")[0]);
            int pla = ConvertMoveToInt(line.Split(" ")[1]);

            int result = GetMatchResult(opp, pla);
            sum += CalculateRoundSum(result, pla);
        }
        return sum;
    }



    public static int Part2()
    {
        string text = Source.GetEntireSource(2);
        string[] lines = text.Split('\n');

        int sum = 0;
        foreach (string line in lines)
        {
            int opp = ConvertMoveToInt(line.Split(" ")[0]);
            int outcome = ConvertMoveToInt(line.Split(" ")[1]);

            int pla = CalculatePlayerMove(opp, outcome);

            sum += CalculateRoundSum(outcome, pla);
        }

        return sum;
    }




    public static int GetMatchResult(int opp, int pla)
    {

        if (opp == pla)
        {
            return 1;
        }
        else if (pla == opp + 1 || opp == pla + 2)
        {
            return 2;
        }
        else
        {
            return 0;
        }
    }



    public static int ConvertMoveToInt(string input)
    {
        char move = input[0];
        int convertedMove;
        switch (move)
        {
            case 'A': convertedMove = 0; break;
            case 'B': convertedMove = 1; break;
            case 'C': convertedMove = 2; break;

            case 'X': convertedMove = 0; break;
            case 'Y': convertedMove = 1; break;
            case 'Z': convertedMove = 2; break;

            default: convertedMove = -1; break;
        }
        return convertedMove;
    }



    public static int CalculateRoundSum(int result, int pla)
    {
        int sum = 0;

        switch (result)
        {
            case 2: sum += 6; break;
            case 1: sum += 3; break;
            case 0: sum += 0; break;
        }

        switch (pla)
        {
            case 0: sum += 1; break;
            case 1: sum += 2; break;
            case 2: sum += 3; break;
        }

        return sum;
    }


    public static int CalculatePlayerMove(int opp, int outcome)
    {
        int pla = opp + (outcome - 1);

        if (pla == -1) { pla = 2; }
        if (pla == 3) { pla = 0; }

        return pla;
    }
}
