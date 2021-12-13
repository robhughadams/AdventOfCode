var lines = File.ReadAllLines("input");

const int gridSize = 1500;
var grid = new bool[gridSize][];
for (var i = 0; i < gridSize; i++)
	grid[i] = new bool[gridSize];

var folds = new List<string>();

var afterBlank = false;
foreach (var line in lines.Reverse())
{
	if (afterBlank)
	{
		var values = line.Split(',');
		var x = int.Parse(values[0]);
		var y = int.Parse(values[1]);

		var fold = folds.Last();
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

		grid[y][x] = true;

		continue;
	}

	if (line == string.Empty)
	{
		afterBlank = true;
		continue;
	}

	folds.Add(line);
}

var dots = 0;
for (var y = 0; y < gridSize; y++)
{
	for (var x = 0; x < gridSize; x++)
	{
		if (grid[y][x])
			dots++;

		// Console.Write(grid[y][x] ? '#' : '.');
	}
	// Console.WriteLine();
}

Console.WriteLine();

Console.WriteLine("Number of dots: " + dots);
