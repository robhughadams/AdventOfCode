var lines = File.ReadAllLines("input");

const string forward = "forward";
const string down = "down";
const string up = "up";

var depth = 0;
var horizontalPosition = 0;

foreach (var line in lines)
{
    if (line.StartsWith(forward))
    {
        var x = int.Parse(line[forward.Length..]);
        horizontalPosition += x;
    }
    else if (line.StartsWith(down))
    {
        var x = int.Parse(line[down.Length..]);
        depth += x;
    }
    else if (line.StartsWith(up))
    {
        var x = int.Parse(line[up.Length..]);
        depth -= x;
    }
}

Console.WriteLine("Depth is: " + depth);
Console.WriteLine("Horizontal Position is: " + horizontalPosition);

Console.WriteLine("Product of depth and horizontalPosition is: " + depth * horizontalPosition);