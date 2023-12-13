var lines = File.ReadAllLines("input");

var sum = 0;
foreach (var line in lines)
{
    var notes = line.Split('|');

    var signalPatterns = notes[0].Trim().Split(' ');
    var outputValues = notes[1].Trim().Split(' ');

    // x 0 = 6 - no d
    // x 1 = 2
    // x 2 = 5
    // x 3 = 5
    // x 4 = 4
    // x 5 = 5
    //   6 = 6
    // x 7 = 3
    // x 8 = 7
    // x 9 = 6 - no e

    string? one = null;
    string? four = null;
    string? seven = null;
    string? eight = null;

    foreach (var signalPattern in signalPatterns)
    {
        switch (signalPattern.Length)
        {
            case 2:
                one = signalPattern;
                break;

            case 4:
                four = signalPattern;
                break;

            case 3:
                seven = signalPattern;
                break;

            case 7:
                eight = signalPattern;
                break;
        }
    }

    Console.WriteLine("One: " + one);
    Console.WriteLine("Four: " + four);
    Console.WriteLine("Seven: " + seven);
    Console.WriteLine("Eight: " + eight);

    var segmentA = seven.Except(one).Single();
    Console.WriteLine("Segment A: " + segmentA);

    var segmentsCandF = one.Intersect(four).ToArray();
    var segmentsBandD = four.Except(one).ToArray();
    Console.WriteLine("Segments C and F: " + new string(segmentsCandF));
    Console.WriteLine("Segments B and D: " + new string(segmentsBandD));

    var zero = signalPatterns
        .Where(
            x => x.Length == 6
            && (!x.Contains(segmentsBandD[0]) || !x.Contains(segmentsBandD[1])))
        .Single();
    Console.WriteLine("Zero: " + zero);

    var segmentD = eight.Except(zero).First();
    Console.WriteLine("Segment D: " + segmentD);

    var three = signalPatterns
        .Where(
            x => x.Length == 5
            && x.Contains(segmentsCandF[0])
            && x.Contains(segmentsCandF[1]))
        .Single();
    Console.WriteLine("Three: " + three);

    var segmentsAandDandG = three.Except(one).ToArray();
    Console.WriteLine("Segments A, D and G: " + new string(segmentsAandDandG));

    var segmentG = segmentsAandDandG.Except(new[] { segmentA, segmentD }).First();
    Console.WriteLine("Segment G: " + segmentG);

    var nine = signalPatterns
        .Where(
            x => x.Length == 6
            && x.Contains(segmentsCandF[0])
            && x.Contains(segmentsCandF[1])
            && x.Contains(segmentD))
        .Single();
    Console.WriteLine("Nine: " + nine);

    var segmentE = eight.Except(nine).Single();
    Console.WriteLine("Segment E: " + segmentE);

    var two = signalPatterns
        .Where(
            x => x.Length == 5
            && x.Contains(segmentE))
        .Single();
    Console.WriteLine("Two: " + two);

    var five = signalPatterns
        .Except(new[] { two, three })
        .Where(x => x.Length == 5)
        .Single();
    Console.WriteLine("Five: " + five);
          
    var six = signalPatterns
        .Except(new[] { zero, one, two, three, four, five, seven, eight, nine })
        .Single();
    Console.WriteLine("Six: " + six);

    static bool LettersMatch (string a, string b)
    {
        return a.Length == b.Length
            && !a.Except(b).Any(); 
    }

    int FindMatch(string value)
    {
        if (LettersMatch(zero, value))
            return 0;

        if (LettersMatch(one, value))
            return 1;

        if (LettersMatch(two, value))
            return 2;

        if (LettersMatch(three, value))
            return 3;

        if (LettersMatch(four, value))
            return 4;

        if (LettersMatch(five, value))
            return 5;

        if (LettersMatch(six, value))
            return 6;

        if (LettersMatch(seven, value))
            return 7;

        if (LettersMatch(eight, value))
            return 8;

        if (LettersMatch(nine, value))
            return 9;

        return -1;
    }

    var outputValue = int.Parse(string.Concat(outputValues.Select(outputDigit =>
    {
        var match = FindMatch(outputDigit);
        Console.WriteLine($"{outputDigit}: {match}");
        return match.ToString();
    })));

    Console.WriteLine("Output value: " + outputValue);
    sum += outputValue;
}

Console.WriteLine("Sum of output values: " + sum);
