using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input");

        var increases = 0;

        int? lastDepth = null;
        for (var i = 0; i < lines.Length - 2; i++)
        {
            static int P(string line) => int.Parse(line);

            var depth = P(lines[i])
                + P(lines[i + 1])
                + P(lines[i + 2]);

            string message;
            if (lastDepth == null)
            {
                message = "N/A - no previous sum";
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

            var window = GetWindow(i);
            Console.WriteLine($"{window}: {depth} ({message})");
            lastDepth = depth;
        }

        Console.WriteLine($"There were {increases} increases");

    }

    private static string GetWindow(int i)
    {
        var list = new LinkedList<int>();

        const int @base = 26;

        i++;

        while (i > @base)
        {
            int value = i % @base;
            if (value == 0)
            {
                i = i / @base - 1;
                list.AddFirst(@base);
            }
            else
            {
                i /= @base;
                list.AddFirst(value);
            }
        }

        if (i > 0)
        {
            list.AddFirst(i);
        }
        return new string(list.Select(s => (char)('A' + s - 1)).ToArray());
    }
}
