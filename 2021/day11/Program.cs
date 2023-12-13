var lines = File.ReadAllLines("input");

var grid = lines
	.Select(l => l
		.Select(c => c - '0')
		.ToArray())
	.ToArray();

for (var y = 0; y < grid.Length; y++)
{
	for (var x = 0; x < grid[y].Length; x++)
	{
		Console.Write(grid[y][x]);
	}
	Console.WriteLine();
}
Console.WriteLine();

var flashes = 0;
const int numberOfSteps = int.MaxValue;
for (var step = 0; step < numberOfSteps; step++)
{
	for (var y = 0; y < grid.Length; y++)
	{
		for (var x = 0; x < grid[y].Length; x++)
		{
			grid[y][x]++;
		}
	}

	bool flashed;
	do
	{
		flashed = false;

		for (var y = 0; y < grid.Length; y++)
		{
			for (var x = 0; x < grid[y].Length; x++)
			{
				if (grid[y][x] > 9)
				{
					flashes++;
					IncrementNeighbours(y, x);
					flashed = true;
					grid[y][x] = int.MinValue;
				}
			}
		}
	} while (flashed);

	var allFlashed = true;
	for (var y = 0; y < grid.Length; y++)
	{
		for (var x = 0; x < grid[y].Length; x++)
		{
			if (grid[y][x] > 9 || grid[y][x] < 0)
			{
				grid[y][x] = 0;
			}
			else
			{
				allFlashed = false;
			}

			Console.Write(grid[y][x]);
		}

		Console.WriteLine();
	}
	
	if (allFlashed)
	{
		Console.WriteLine("All octupusus have flashed! Step: " + (step + 1));
		break;
	}

	Console.WriteLine();
}

Console.WriteLine("Total flashes: " + flashes);

void IncrementNeighbours(int y, int x)
{
	if (y > 0)
	{
		if (x > 0)
			grid[y - 1][x - 1]++;
		grid[y - 1][x    ]++;
		if (x < lines[0].Length - 1)
			grid[y - 1][x + 1]++;
	}

	if (x > 0)
		grid[y    ][x - 1]++;
	if (x < lines[0].Length - 1)
		grid[y    ][x + 1]++;

	if (y < lines.Length - 1)
	{
		if (x > 0)
			grid[y + 1][x - 1]++;
		grid[y + 1][x    ]++;
		if (x < lines[0].Length - 1)
			grid[y + 1][x + 1]++;
	}
}
