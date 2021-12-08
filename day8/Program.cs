var lines = File.ReadAllLines("input");

var counter = 0;
foreach (var line in lines)
{
    var notes = line.Split('|');

    var signalPatterns = notes[0].Trim();
    var outputValues = notes[1].Trim();

    // 1, 4, 7, 8
    // 1 = 2
    // 4 = 4
    // 7 = 3
    // 8 = 7

    foreach (var outputValue in outputValues.Split(' '))
    {
        switch (outputValue.Length)
        {
            case 2:
            case 4:
            case 3:
            case 7:
                counter++;
                break;
        }

    }
}

Console.WriteLine("Number of 1, 4, 7, or 8s in output: " + counter);
