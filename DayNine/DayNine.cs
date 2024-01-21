namespace dotnet_aoc.DayNine;

public static class DayNine
{
    public static long PartOne(string[] input)
    {
        long result = 0;


        foreach (var line in input)
        {
            var sequence = line.Trim().Split(' ').Select(int.Parse).ToArray();

            var extrapolatedNumber = GetExtrapolatedNumber(sequence, Direction.Forward);

            result += extrapolatedNumber;
        }


        return result;
    }

    private static long GetExtrapolatedNumber(int[] sequence, Direction direction)
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


        // FOR BACKWARDS

        var backwardsValue = 0;

        // GOING UP ROWS
        for (var r = row; r > 0; r--)
        {
            // CALCULATE FORWARD
            var lastIdx = sequence.Length - r;
            var difference = matrix[r, lastIdx];
            var valueAbove = matrix[r - 1, lastIdx];

            matrix[r - 1, lastIdx + 1] = valueAbove + difference;

            // CALCULATE BACKWARDS
            difference = backwardsValue;
            valueAbove = matrix[r - 1, 0];
            backwardsValue = valueAbove - difference;
        }


        return direction == Direction.Forward ? matrix[0, sequence.Length] : backwardsValue;
    }

    public static long PartTwo(string[] input)
    {
        long result = 0;


        foreach (var line in input)
        {
            var sequence = line.Trim().Split(' ').Select(int.Parse).ToArray();

            var extrapolatedNumber = GetExtrapolatedNumber(sequence, Direction.Backwards);

            result += extrapolatedNumber;
        }


        return result;
    }
}

enum Direction
{
    Forward,
    Backwards
}