namespace dotnet_aoc.DaySix;

public static class DaySix
{
    public static int PartOne(string[] input)
    {
        var result = new List<int>();


        const int aceleration = 1;

        var times = input[0].Split("Time:")[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToList();

        var records = input[1].Split("Distance:")[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToList();


        for (var i = 0; i < times.Count; i++)
        {
            var numberOfTimesBeatPerTime = 0;

            var time = times[i];
            var record = records[i];

            var buttonPressTime = 1;

            while (buttonPressTime < time)
            {
                var distance = (buttonPressTime * aceleration) * (time - buttonPressTime);

                if (distance > record)
                {
                    numberOfTimesBeatPerTime++;
                }

                buttonPressTime++;
            }

            if (numberOfTimesBeatPerTime > 0)
            {
                result.Add(numberOfTimesBeatPerTime);
            }
        }

        // MUTIPLY ALL VALUES IN RESULT
        return result.Aggregate(1, (acc, x) => acc * x);
    }


    public static long PartTwo(string[] input)
    {
        var result = new List<long>();

        // var input = @"Time:      7  15   30
        //               Distance:  9  40  200".Split('\n');

        const int aceleration = 1;

        var timeDigits = input[0].Split("Time:")[1].Trim().ToCharArray().Where(Char.IsDigit).Select(x => x.ToString())
            .ToList();

        var time = long.Parse(String.Join("", timeDigits));


        var recordDigits = input[1].Split("Distance:")[1].Trim()
            .ToCharArray()
            .Where(Char.IsDigit)
            .Select(x => x.ToString()).ToList();

        var record = long.Parse(String.Join("", recordDigits));


        Console.WriteLine($"Time: {time}");

        Console.WriteLine($"Record: {record}");


        var numberOfTimesBeatPerTime = 0;

        long buttonPressTime = 1;

        while (buttonPressTime < time)
        {
            var distance = (buttonPressTime * aceleration) * (time - buttonPressTime);

            if (distance > record)
            {
                numberOfTimesBeatPerTime++;
            }

            buttonPressTime++;
        }

        return numberOfTimesBeatPerTime;
    }
}