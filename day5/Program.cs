using System.Text;
using System.Text.RegularExpressions;

var lines = File.ReadAllLines("input");

var grid = new Grid();

foreach (var rawLine in lines)
{
    var line = new Line(rawLine);
    grid.Add(line);

    //Console.WriteLine(line);
}

//Console.WriteLine(grid);
Console.WriteLine("Number of overlapping points: " + grid.NumberOfOverlappingPoints());

class Line
{
    private static readonly Regex InputPattern =
        new(@"(?<x1>\d+),(?<y1>\d+) -> (?<x2>\d+),(?<y2>\d+)");

    public int X1 { get; } 
    public int Y1  { get; }
    public int X2 { get; }
    public int Y2 { get; }

    public bool Horizontal => Y1 == Y2;

    public bool Vertical => X1 == X2;

    public Line(string rawLine)
    {
        var results = InputPattern.Match(rawLine);

        X1 = int.Parse(results.Groups["x1"].Value);
        Y1 = int.Parse(results.Groups["y1"].Value);
        X2 = int.Parse(results.Groups["x2"].Value);
        Y2 = int.Parse(results.Groups["y2"].Value);
    }

    public override string ToString()
    {
        return $"x1: {X1:000} y1: {Y1:000} x2: {X2:000} y2: {Y2:000}" +
            (Horizontal ? " - horizontal" : string.Empty) + 
            (Vertical ? " - vertical" : string.Empty);
    }
}

class Grid
{
    private const int Size = 1000;

    readonly int[][] _grid;

    public Grid()
    {
        _grid = new int[Size][];
        
        for (int i = 0; i < Size; i++)
            _grid[i] = new int[Size];
    }

    public void Add(Line line)
    {
        static Func<int, int> GetAdvanceFunction(int a, int b) => a < b ? (i => ++i) : b < a ? (i => --i) : (i => i);

        var advanceX = GetAdvanceFunction(line.X1, line.X2);
        var advanceY = GetAdvanceFunction(line.Y1, line.Y2);

        var x = line.X1;
        var y = line.Y1;
        SetPoint(x, y);
        while (x != line.X2 || y != line.Y2)
        {
            x = advanceX(x);
            y = advanceY(y);
            SetPoint(x, y);
        }
    }

    public void SetPoint(int x, int y)
    {
        _grid[y][x]++;
    }

    public int NumberOfOverlappingPoints()
    {
        var total = 0;
        for (var i = 0; i < Size; i++)
        {
            for (var j = 0; j < Size; j++)
            {
                if(_grid[i][j] >= 2)
                    total++;
            }
        }

        return total;
    }

    public override string ToString()
    {
        var buffer = new StringBuilder();

        for(var i = 0; i < Size; i++)
        {
            for (var j = 0; j < Size; j++)
            {
                var value = _grid[i][j];
                buffer.Append(value == 0 ? "." : value.ToString());
            }

            buffer.AppendLine();
        }

        return buffer.ToString();
    }
}