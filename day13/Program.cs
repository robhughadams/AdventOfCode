var lines = File.ReadAllLines("input");

const int gridSize = 50;
var grid = new bool[gridSize][];
for (var i = 0; i < gridSize; i++)
	grid[i] = new bool[gridSize];

var folds = new List<string>();

var maxY = 0;

var afterBlank = false;
foreach (var line in lines.Reverse())
{
	if (afterBlank)
	{
		var values = line.Split(',');
		var x = int.Parse(values[0]);
		var y = int.Parse(values[1]);

		foreach (var fold in folds)
		{
			var foldValues = fold.Split('=');
			var foldValue = int.Parse(foldValues[1]);
			if (foldValues[0].Last() == 'x')
			{
				if (x > foldValue)
					x = foldValue - (x - foldValue);
			}
			else
			{
				if (y > foldValue)
					y = foldValue - (y - foldValue);
			}
		}

		if (y > maxY)
			maxY = y;

		grid[y][x] = true;

		continue;
	}

	if (line == string.Empty)
	{
		afterBlank = true;
		folds.Reverse();
		continue;
	}

	folds.Add(line);
}

for (var y = 0; y <= maxY; y++)
{
	for (var x = 0; x < gridSize; x++)
	{
		Console.Write(grid[y][x] ? '#' : ' ');
	}
	Console.WriteLine();
}
