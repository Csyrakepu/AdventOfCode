namespace AdventOfCode2023;
class Day10
{
    public static int Part1()
    {
        char[][] gridSource = Source.GetSourceGrid(10);
        Tile[][] grid = InitGrid(gridSource);

        return 0;
    }

    public static int Part2()
    {
        return 0;
    }

    public static int Test()
    {
        Tile tile = new Tile('7', (23, 12));
        Write.Multiple(tile.down, tile.up, tile.left, tile.right);
        return 0;
    }

    static (int x, int y) FindStartingCoords(char[][] grid)
    {
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] =='S') { return (i, j);}
            }
        }
        return (-1, -1);
    }

    static Tile[][] InitGrid(char[][] gridSource)
    {
        var grid = new Tile[gridSource.Length][];
        for (int i = 0;i < gridSource.Length;i++)
        {
            for (int j = 0; j < gridSource[i].Length; j++)
            {
                grid[i][j] = new Tile(gridSource[i][j], (i, j));
            }
        }
        return grid;
    }
}

class Tile
{
    public char Symbol { get; set; }
    public (int x, int y) Coords { get; set; }


    public bool up;
    public bool down;
    public bool left;
    public bool right;

    public Tile(char symbol, (int x, int y) coords)
    {
        Symbol = symbol;
        Coords = coords;
        SetConnections();
    }

    void SetConnections()
    {
        switch (Symbol)
        {
            case '|':
                up = true;
                down = true;
                break;
            case '-':
                left = true;
                right = true;
                break;
            case 'L':
                up = true;
                right = true;
                break;
            case 'J':
                up = true;
                left = true;
                break;
            case '7':
                down = true;
                left = true;
                break;
            case 'F':
                down = true;
                right = true;
                break;
        }
    }
}