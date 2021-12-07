using System.Collections;

var lines = File.ReadAllLines("input");

var shoal = new Shoal();
foreach(var fish in lines[0].Split(',')
    .Select(x => new LanternFish(int.Parse(x), shoal)))
{
    shoal.Add(fish);
}

// Console.WriteLine($"Initial state: {string.Join(',', shoal)}");

const int daysToRun = 80;

for (var i = 1; i <= daysToRun; i++)
{
    foreach (var fish in shoal.ToArray()) // Create a copy of the shoal
    {
        fish.IncrementTimer();
    }

    // Console.WriteLine($"After {i:00} day{(i > 1 ? "s" : " ")}: {string.Join(',', shoal)}");
}

Console.WriteLine("Number of fish: " + shoal.Count);

class LanternFish
{
    private readonly Shoal _shoal;

    private int _timerValue;

    public LanternFish(int timerValue, Shoal shoal)
    {
        _timerValue = timerValue;
        _shoal = shoal;
    }

    public void IncrementTimer()
    {
        _timerValue--;

        if (_timerValue == -1)
        {
            _timerValue = 6;
            _shoal.Add(new LanternFish(8, _shoal));
        }
    }

    public override string ToString()
    {
        return _timerValue.ToString();
    }
}

class Shoal : List<LanternFish>
{
}