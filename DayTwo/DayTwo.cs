namespace dotnet_aoc.DayTwo;

public static class DayTwo
{
    public static int PartOne(string[] input)
    {
        // MAX CUBES FOR THE GAME
        Dictionary<string, int> maxCubes = new()
        {
            { "blue", 14 },
            { "green", 13 },
            { "red", 12 }
        };

        var validIds = new List<int>();

        foreach (var line in input)
        {
            var gameId = int.Parse(line.Split(':')[0].Replace("Game ", ""));

            var sets = line.Split(':')[1].Split(';').Select(x => x.Trim()).ToList();

            var valid = true;

            foreach (var set in sets)
            {
                var colors = set.Split(',');


                foreach (var color in colors)
                {
                    var colorName = color.Trim().Split(' ')[1];

                    var colorCount = int.Parse(color.Trim().Split(' ')[0]);

                    if (colorCount > maxCubes[colorName])
                    {
                        valid = false;
                        break;
                    }
                }

                if (!valid)
                {
                    break;
                }
            }

            if (valid)
            {
                validIds.Add(gameId);
            }
        }

        return validIds.Sum();
    }

    public static int PartTwo(string[] input)
    {
        // RED | GREEN | BLUE
        var minimunCubesPerGame = new List<(int, int, int)>();

        foreach (var line in input)
        {
            var sets = line.Split(':')[1].Split(';').Select(x => x.Trim()).ToList();

            var red = 0;
            var green = 0;
            var blue = 0;

            foreach (var set in sets)
            {
                var colors = set.Split(',');

                foreach (var color in colors)
                {
                    var colorName = color.Trim().Split(' ')[1];

                    var colorCount = int.Parse(color.Trim().Split(' ')[0]);

                    if (colorName == "red")
                    {
                        red = colorCount > red ? colorCount : red;
                    }
                    else if (colorName == "green")
                    {
                        green = colorCount > green ? colorCount : green;
                    }
                    else if (colorName == "blue")
                    {
                        blue = colorCount > blue ? colorCount : blue;
                    }
                }
            }

            minimunCubesPerGame.Add((red, green, blue));
        }

        var result = minimunCubesPerGame.Select((colors) => colors.Item1 * colors.Item2 * colors.Item3).ToList().Sum();

        return result;
    }
}