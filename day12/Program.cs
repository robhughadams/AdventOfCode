var lines = File.ReadAllLines("input");

var nodes = new Dictionary<string, List<string>>();

void AddVertex(string start, string end)
{
	nodes.TryAdd(start, new List<string>());
	nodes[start].Add(end);
}
	
foreach (var line in lines)
{
	var parts = line.Split('-');
	var a = parts[0];
	var b = parts[1];

	AddVertex(a, b);
	AddVertex(b, a);
}

var paths = new List<List<string>>();

FindPath("start", new List<string>());

void FindPath(string node, List<string> path)
{
	paths.Add(path);

	path.Add(node);

	if (node == "end")
		return;

	var linkedNodes = nodes[node].Where(n => !(FirstCharIsLower(n) && path.Contains(n)));

	foreach (var linkedNode in linkedNodes)
	{
		FindPath(linkedNode, path.ToList());
	}
}

paths = paths.Where(p => p.Last() == "end").ToList();
foreach (var path in paths)
{
	Console.WriteLine(string.Join(',', path));
}

Console.WriteLine("Number of paths: " + paths.Count);

static bool FirstCharIsLower(string s)
{
	return char.IsLower(s[0]);
}
