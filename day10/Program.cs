var lines = File.ReadAllLines("input");

const string openingChars = "([{<";
const string closingChars = ")]}>";

var score = 0;
foreach (var line in lines)
{
	var stack = new Stack<char>();

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
				Console.WriteLine($"Syntax Error: Expected {closingChars[openingChars.IndexOf(opener)]}, but found {c}");
				score += c switch
				{
					')' => 3,
					']' => 57,
					'}' => 1197,
					'>' => 25137,
					_ => 0
				};
				break;
			}
		}
	}
}

Console.WriteLine("Score: " + score);
