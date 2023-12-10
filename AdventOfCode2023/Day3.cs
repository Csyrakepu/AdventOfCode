namespace AdventOfCode2023;
class Day3
{
    public static int Part1()
    {
        string[] lines = Source.GetSourceLines(3);

        List<Number> numbers = new List<Number>();
        List<Symbol> symbols = new List<Symbol>();
        CreateObjects(lines, numbers, symbols);
        return numbers.Sum(number => number.GetPartNumber(symbols));
    }

    public static int Part2()
    {
        string[] lines = Source.GetSourceLines(3);

        List<Number> numbers = new List<Number>();
        List<Symbol> symbols = new List<Symbol>();
        CreateObjects(lines, numbers, symbols);

        return symbols.Sum(symbol => symbol.GetGearRatio(numbers));
    }

    static void CreateObjects(string[] lines, List<Number> numbers, List<Symbol> symbols)
    {
        for (int lineNumber = 0; lineNumber < lines.Length; lineNumber++)
        {
            string line = lines[lineNumber];

            string buffer = "";
            for (int columnNumber = 0; columnNumber < line.Length; columnNumber++)
            {
                char c = line[columnNumber];

                if (char.IsDigit(c))
                {
                    buffer += c;
                    continue;
                }

                if (buffer.Length != 0)
                {
                    int number = int.Parse(buffer);
                    Number current = new Number(number, lineNumber, buffer.Length, columnNumber - 1);
                    numbers.Add(current);
                    buffer = "";
                }

                if (c == '.' || columnNumber == line.Length - 1) continue;
                else
                {
                    Symbol current = new Symbol(c, lineNumber, columnNumber);
                    symbols.Add(current);
                }
            }
        }
    }
}


class Number
{
    public readonly int value;
    public readonly int line;
    public readonly int start;
    public readonly int end;
    public readonly int length;
    public readonly int[] occupiedSlots;

    public Number(int value, int line, int length, int end)
    {
        this.value = value;
        this.line = line;
        this.length = length;
        this.end = end;
        this.start = end - (length - 1);
        this.occupiedSlots = Enumerable.Range(start, length).ToArray();
    }

    public bool IsAdjacent(Symbol symbol)
    {
        List<int> possibleLines = new List<int> { line, line + 1, line - 1 };
        List<int> possibleColumns = Enumerable.Range(start - 1, length + 2).ToList();
        return possibleLines.Contains(symbol.line) && possibleColumns.Contains(symbol.column);
    }

    public int GetPartNumber(List<Symbol> symbols)
    {
        bool isPartNumber = symbols.Exists(IsAdjacent);
        return (isPartNumber) ? value : 0;
    }


    public override string ToString()
    {
        return $"{value}; {line}, {start}-{end}; {length}";
    }

}

class Symbol
{
    public readonly char symbol;
    public readonly int line;
    public readonly int column;

    public Symbol(char symbol, int line, int column)
    {
        this.symbol = symbol;
        this.line = line;
        this.column = column;
    }

    public int GetGearRatio(List<Number> numbers)
    {
        if (symbol != '*') return 0;
        List<Number> adjacentNumbers = numbers.Where(n => n.IsAdjacent(this)).ToList();
        if (adjacentNumbers.Count != 2) return 0;
        return adjacentNumbers[0].value * adjacentNumbers[1].value;
    }

    public override string ToString()
    {
        return $"{symbol} {line},{column}";
    }
}
