var lines = File.ReadAllLines("input");

var map = new HeightMap(lines);

Console.WriteLine("Map height: " + map.Height);
Console.WriteLine("Map width: " + map.Width);

var basins = new List<Basin>();

for (var y = 0; y < map.Height; y++)
{
	var basin = new Basin();
	basins.Add(basin);

	for (var x = 0; x < map.Width; x++)
	{
		var point = map.GetPointAt(x, y);
		if (point.Value < 9)
		{
			var previousRowBasin = map.GetPointAt(x, y - 1).Basin;
			if (previousRowBasin != null && previousRowBasin != basin)
			{
				// Console.WriteLine($"Combining basins x: {x} y: {y} value: {point.Value}");
				// Console.WriteLine($"Previous row basin size: {previousRowBasin.Size} values: {string.Join(',', previousRowBasin.Points.Select(p => p.Value))}");
				previousRowBasin.Add(basin);
				basins.Remove(basin);
				basin = previousRowBasin;
			}

			// Console.WriteLine($"Adding point x: {x} y: {y} value: {point.Value}");
			basin.Add(point);
			// Console.WriteLine($"Basin size: {basin.Size} values: {string.Join(',', basin.Points.Select(p => p.Value))}");
		}
		else
		{
			basin = new Basin();
			basins.Add(basin);
		}
	}
}

Console.WriteLine("Number of basins: " + basins.Count(b => b.Size > 0));

var answer = basins
	.Select(b => b.Size)
	.OrderByDescending(s => s)
	.Take(3)
	.Aggregate(1, (x, y) => x * y);
Console.WriteLine("Product of 3 largest basins: " + answer);

class Point
{
	public int Value { get; }

	public Basin? Basin { get; set; }

	public Point(int value)
	{
		Value = value;
	}
}

class Basin
{
	public HashSet<Point> Points { get; } = new HashSet<Point>();

	public int Size => Points.Count;

	public void Add(Point point)
	{
		point.Basin = this;
		Points.Add(point);
	}

	public void Add(Basin basin)
	{
		foreach (var point in basin.Points)
		{
			Add(point);
		}
	}
}

class HeightMap
{
	public int Height { get; }
	public int Width { get; }

	private readonly Point[][] _points;

	public HeightMap(string[] lines)
	{
		Height = lines.Length;
		Width = lines[0].Length;
		_points = lines
			.Select(l => l
				.Select(p => new Point(int.Parse(p.ToString())))
			    .ToArray())
		    .ToArray();
	}

	public Point GetPointAt(int x, int y)
	{
		if (x < 0 || y < 0 || x >= Width || y >= Height)
			return new Point(int.MaxValue);

		return _points[y][x];
	}
}
