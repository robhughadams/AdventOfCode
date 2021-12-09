var lines = File.ReadAllLines("input");

var map = new HeightMap(lines);

Console.WriteLine("Map height: " + map.Height);
Console.WriteLine("Map width: " + map.Width);

var totalRisk = 0;
for (var y = 0; y < map.Height; y++)
{
	for (var x = 0; x < map.Width; x++)
	{
		var point = map.GetValueAt(x    , y    );

		var up    = map.GetValueAt(x    , y - 1);
		var down  = map.GetValueAt(x    , y + 1);
		var left  = map.GetValueAt(x - 1, y    );
		var right = map.GetValueAt(x + 1, y    );

		if (point < up && point < down && point < left && point < right)
		{
			var risk = point + 1;
			totalRisk += risk;
			Console.WriteLine($"Low point: {x},{y} {point} risk: {risk}");
		}
	}
}

Console.WriteLine("Total risk is: " + totalRisk);

class HeightMap
{
	public int Height { get; }
	public int Width { get; }

	private readonly string[] _lines;

	public HeightMap(string[] lines)
	{
		Height = lines.Length;
		Width = lines[0].Length;
		_lines = lines;
	}

	public int GetValueAt(int x, int y)
	{
		if (x < 0 || y < 0 || x >= Width || y >= Height)
			return int.MaxValue;

		var value = int.Parse(_lines[y][x].ToString());
		// Console.WriteLine($"Value at: {x},{y} = {value}");

		return value;
	}
}
