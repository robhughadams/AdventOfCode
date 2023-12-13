var lines = File.ReadAllLines("input");

var lineLength = lines[0].Length; // all lines are the same length

static string FindValue(
    List<string> startLines,
    int lineLength,
    Func<int, int, char> valueSelector)
{
    var linesToKeep = new List<string>();

    for (var i = 0; i < lineLength; i++)
    {
        var numberOfOnes = 0;
        var numberOfZeros = 0;
        foreach (var line in startLines)
        {
            if (line[i] == '1')
                numberOfOnes++;
            else
                numberOfZeros++;
        }

        char valueToKeep = valueSelector(numberOfOnes, numberOfZeros);
        Console.WriteLine("Value to keep is: " + valueToKeep);

        foreach (var line in startLines)
        {
            if (line[i] == valueToKeep)
                linesToKeep.Add(line);
        }

        if (linesToKeep.Count == 1)
            break;

        startLines = linesToKeep;
        linesToKeep = new List<string>();
    }

    Console.WriteLine("Number of lines to keep: " + linesToKeep.Count);

    Console.WriteLine("Value is: " + linesToKeep[0]);

    return linesToKeep[0];
}

var oxygenValue = FindValue(
    lines.ToList(),
    lineLength,
    (numberOfOnes, numberOfZeros) => numberOfOnes >= numberOfZeros ? '1' : '0'
);
var oxygen = Convert.ToInt32(oxygenValue, 2);

var co2Value = FindValue(
    lines.ToList(),
    lineLength,
    (numberOfOnes, numberOfZeros) => numberOfOnes >= numberOfZeros ? '0' : '1'
);
var co2 = Convert.ToInt32(co2Value, 2);

Console.WriteLine("Oxygen generator rating is: " + oxygen);
Console.WriteLine("CO2 scrubber rating: " + co2);

Console.WriteLine("Product is: " + oxygen * co2);