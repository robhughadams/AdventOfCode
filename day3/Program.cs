var lines = File.ReadAllLines("input");

var lineLength = lines[0].Length; // all lines are the same length

var bitCounts = new int[lineLength];

foreach (var line in lines)
{
    for (var i = 0; i < lineLength; i++)
    {
        if (line[i] == '1')
            bitCounts[i]++;
    }
}

Console.WriteLine("Bit counts are: " + string.Join(", ", bitCounts));
Console.WriteLine("Line count is: " + lines.Length);

var halfwayPoint = lines.Length / 2;
Console.WriteLine("Halfway point is: " + halfwayPoint);

var gammaValues = new char[lineLength];
var epsilonValues = new char[lineLength];

for (var i = 0; i < lineLength; i++)
{
    if (bitCounts[i] > halfwayPoint)
    {
        gammaValues[i] = '1';
        epsilonValues[i] = '0';
    }
    else
    {
        gammaValues[i] = '0';
        epsilonValues[i] = '1';
    }
}

var gammaString = new string(gammaValues);
var epsilonString = new string(epsilonValues);

Console.WriteLine("Gamma string is: " + gammaString);
Console.WriteLine("Epsilon string is: " + epsilonString);

var gamma = Convert.ToInt32(gammaString, 2);
var epsilon = Convert.ToInt32(epsilonString, 2);

Console.WriteLine("Gamma is: " + gamma);
Console.WriteLine("Epsilon is: " + epsilon);

Console.WriteLine("Product is: " + gamma * epsilon);