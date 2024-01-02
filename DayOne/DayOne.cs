namespace dotnet_aoc.DayOne;

public class DayOne
{
    public static int PartOne(string[] input)
    {
        var numbersPerLine = new List<(int, int)>();

        foreach (var line in input)
        {
            var numbers = new List<int>();
            foreach (var character in line)
                if (char.IsDigit(character))
                    numbers.Add(int.Parse(character.ToString()));

            numbersPerLine.Add((numbers[0], numbers[^1]));
        }

        var result = numbersPerLine.Select(x => x.Item1 * 10 + x.Item2).Sum();

        return result;
    }

    public static int PartTwo(string[] input)
    {
        var dictionary = new Dictionary<string, int>
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };

        const int range = 10;

        for (var i = 1; i < range; i++)
        {
            dictionary.Add(i.ToString(), i);
        }

        var numbersPerLine = new List<(int, int)>();


        foreach (var line in input)
        {
            var firstIndex = line.Length;
            var lastIndex = -1;
            var firstValue = 0;
            var lastValue = 0;


            foreach (var digit in dictionary)
            {
                var index = line.IndexOf(digit.Key, StringComparison.Ordinal);

                // If the digit is not in the line, it will be skipped
                if (index == -1) continue;

                if (index < firstIndex)
                {
                    firstIndex = index;
                    firstValue = digit.Value;
                }

                index = line.LastIndexOf(digit.Key, StringComparison.Ordinal);

                if (index > lastIndex)
                {
                    lastIndex = index;
                    lastValue = digit.Value;
                }
            }

            numbersPerLine.Add((firstValue, lastValue));
        }

        var result = numbersPerLine.Select(x => x.Item1 * 10 + x.Item2).Sum();

        return result;
    }
}