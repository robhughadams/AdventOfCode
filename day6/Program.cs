var lines = File.ReadAllLines("input");

var shoal = new Shoal();
foreach(var timerValue in lines[0].Split(',')
    .Select(x => int.Parse(x)))
{
    shoal.Add(timerValue);
}

// Console.WriteLine(shoal);

const int daysToRun = 256;

for (var day = 1; day <= daysToRun; day++)
{
    shoal.IncrementTimers();

    Console.WriteLine($"After {day:000} days there are {shoal.Count()} fish");
    // Console.WriteLine(shoal);
}

Console.WriteLine("Number of fish: " + shoal.Count());

class Shoal
{
    private readonly Dictionary<int, long> _timers = new();

    public Shoal()
    {
        for (var i = 0; i <= 8; i++)
        {
            _timers.Add(i, 0);
        }
    }

    public void Add(int timerValue)
    {
        _timers[timerValue]++;
    }

    public void IncrementTimers()
    {
        var reproductiveFish = _timers[0];

        for (var i = 0; i < 8; i++)
        {
            _timers[i] = _timers[i + 1];
        }

        _timers[6] += reproductiveFish; // Reset the parents
        _timers[8] = reproductiveFish; // Add the offspring
    }

    public long Count()
    {
        var count = 0L;
        for (var i = 0; i <= 8; i++)
        {
            count += _timers[i];
        }
        return count;
    }

    public override string ToString()
    {
        return string.Join(',', _timers);
    }
}