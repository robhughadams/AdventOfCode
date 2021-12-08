var lines = File.ReadAllLines("input");

var positions = lines[0].Split(',')
    .Select(x => int.Parse(x));

var maxPosition = positions.Max();

var minCost = int.MaxValue;
var bestPos = -1;
for (var i = 0; i <= maxPosition; i++)
{
    var cost = 0;
    foreach (var position in positions)
    {
        var numberOfSteps = Math.Abs(position - i);
        for (var step = 1; step <= numberOfSteps; step++)
        {
            cost += step;
        }
    }

    Console.WriteLine($"Cost for position {i} is {cost}");
    if (cost < minCost)
    {
        minCost = cost;
        bestPos = i;
    }
}

Console.WriteLine($"Position with lowest cost is {bestPos} with cost {minCost}");