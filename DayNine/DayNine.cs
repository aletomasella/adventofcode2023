namespace dotnet_aoc.DayNine;

public static class DayNine
{
    public static long PartOne(string[] input)
    {
        // var input = @"0 3 6 9 12 15
        //             1 3 6 10 15 21
        //             10 13 16 21 30 45".Split('\n');

        long result = 0;


        foreach (var line in input)
        {
            var sequence = line.Trim().Split(' ').Select(int.Parse).ToArray();

            var extrapolatedNumber = GetExtrapolatedNumber(sequence);

            result += extrapolatedNumber;
        }


        return result;
    }

    private static long GetExtrapolatedNumber(int[] sequence)
    {
        var matrix = new int[sequence.Length + 1, sequence.Length + 1];

        var allZeros = false;

        for (var i = 0; i < sequence.Length; i++)
        {
            // FIRST ROW OF MATRIX
            matrix[0, i] = sequence[i];
        }

        var row = 0;

        while (!allZeros)
        {
            allZeros = true;

            for (var i = 0; i < sequence.Length - 1 - row; i++)
            {
                var leftValue = matrix[row, i];
                var rightValue = matrix[row, i + 1];
                var difference = rightValue - leftValue;


                matrix[row + 1, i] = difference;

                if (difference != 0)
                {
                    allZeros = false;
                }
            }

            row++;
        }


        // GOING UP ROWS
        for (var r = row; r > 0; r--)
        {
            var lastIdx = sequence.Length - r;
            var difference = matrix[r, lastIdx];
            var valueAbove = matrix[r - 1, lastIdx];

            matrix[r - 1, lastIdx + 1] = valueAbove + difference;
        }

        var result = matrix[0, sequence.Length];

        // Console.WriteLine($"RESULT: {result}");

        return matrix[0, sequence.Length];
    }

    public static int PartTwo(string[] input)
    {
        return 0;
    }
}