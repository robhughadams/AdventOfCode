var lines = File.ReadAllLines("input");

var numbersDrawn = lines[0].Split(',')
    .Select(x => int.Parse(x))
    .ToArray();

var boardLines = lines.Skip(2).ToArray();
var boards = new List<Board>();

for (var i = 0; i < boardLines.Length; i += 6)
{
    boards.Add(new Board(boardLines[i..(i + 5)]));
}


var position = 0;
foreach (var number in numbersDrawn)
{
    Console.WriteLine("Checking: " + number);

    foreach (var board in boards.Where(b => b.Score == 0))
    {
        board.Mark(number);

        if (board.Bingo())
        {
            board.CalculateScore(number);
            board.Position = position;
            position++;
        }
    }
}

var lastBoard = boards.OrderBy(b => b.Position).Last();

Console.WriteLine(lastBoard);
Console.WriteLine("Board score: " + lastBoard.Score);

class Board
{
    public int Position { get; set; }
    public int Score { get; private set; }

    readonly BoardValue[][] _values = new BoardValue[5][];

    public Board(string[] lines)
    {
        for (var i = 0; i < 5; i++)
        {
            _values[i] = new BoardValue[5];

            for (var j = 0; j < 5; j++)
            {
                var pos = j * 3;
                _values[i][j] = int.Parse(lines[i][pos..(pos + 2)]);
            }
        }
    }
    
    public void Mark(int number)
    {
        for (var i = 0; i < 5; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                if (_values[i][j] == number)
                {
                    _values[i][j].Matched = true;
                }
            }
        }
    }

    public bool Bingo()
    {
        for (var i = 0; i < 5; i++)
        {
            var bingo = true;
            for (var j = 0;j < 5; j++)
            {
                bingo &= _values[i][j].Matched;
            }

            if (bingo)
                return true;
        }

        for (var i = 0; i < 5; i++)
        {
            var bingo = true;
            for (var j = 0;j < 5; j++)
            {
                bingo &= _values[j][i].Matched;
            }

            if (bingo)
                return true;
        }

        return false;
    }

    public void CalculateScore(int lastNumber)
    {
        Score = _values.Sum(row => row
            .Where(v => !v.Matched)
            .Sum(x => x.Value)) * lastNumber;
    }

    public override string ToString()
    {
        return string.Join('\n', _values.Select(x => string.Join(", ", x)));
    }
}

struct BoardValue
{
    public bool Matched { get; set; }
    public int Value { get; set; }

    public static implicit operator BoardValue(int value)
    {
        return new BoardValue { Value = value };
    }

    public static implicit operator int(BoardValue value)
    {
        return value.Value;
    }

    public override string ToString()
    {
        return $"{Value:00} {(Matched ? 'y' : 'n')}";
    }
}