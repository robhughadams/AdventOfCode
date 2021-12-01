var lines = File.ReadAllLines("input");

var increases = 0;

int? lastDepth = null;
foreach (var line in lines)
{
    var depth = int.Parse(line);

    string message;
    if (lastDepth == null)
    {
        message = "N/A - no previous measurement";
    }
    else if (depth > lastDepth)
    {
        message = "increased";
        increases++;
    }
    else
    {
        message = "decreased";
    }

    Console.WriteLine($"{line} ({message})");
    lastDepth = depth;
}

Console.WriteLine($"There were {increases} increases");