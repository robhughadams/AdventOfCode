var lines = File.ReadAllLines("input");

const string openingChars = "([{<";
const string closingChars = ")]}>";

var scores = new List<long>();
foreach (var line in lines)
{
	var stack = new Stack<char>();

	var invalid = false;
	foreach (var c in line)
	{
		if (openingChars.Contains(c))
		{
			// Console.WriteLine("Pushing: " + c);
			stack.Push(c);
		}
		if (closingChars.Contains(c))
		{
			// Console.WriteLine("Closing char: " + c);
			var opener = stack.Pop();
			// Console.WriteLine("Poping: " + opener);

			if (openingChars.IndexOf(opener) != closingChars.IndexOf(c))
			{
				invalid = true;
				break;
			}
		}
	}

	if (invalid)
		continue;

	var score = 0L;
	foreach (var c in stack)
	{
		Console.Write(c);
		score *= 5;
		score += c switch
		{
			'(' => 1,
			'[' => 2,
			'{' => 3,
			'<' => 4,
			_ => 0
		};
	}
	if (score > 0)
	{
		Console.WriteLine(" : " + score);
		scores.Add(score);
	}
}

scores.Sort();
Console.WriteLine("Number of scores: " + scores.Count);
var middleScore = scores[scores.Count / 2];
Console.WriteLine("Middle score: " + middleScore);
