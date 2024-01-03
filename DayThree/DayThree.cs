namespace dotnet_aoc.DayThree;

public static class DayThree
{
    public static long PartOne(string[] input)
    {
        var validNumbers = new List<int>();
        var coordinates = new List<Coordinate>();

        for (var i = 0; i < input.Length; i++)
        {
            var chars = input[i].ToCharArray();

            for (var j = 0;
                 j < chars.Length;
                 j++)
            {
                if (chars[j] != '.' && !char.IsDigit(chars[j]))
                {
                    coordinates.Add(new Coordinate(i, j));
                }
            }
        }

        for (var i = 0; i < input.Length; i++)
        {
            var chars = input[i].ToCharArray();

            for (var j = 0;
                 j < chars.Length;
                 j++)
            {
                if (char.IsDigit(chars[j]))
                {
                    var firstIndex = j;
                    var lastIndex = j;
                    var number = chars[j].ToString();
                    for (int k = j + 1; k < chars.Length; k++)
                    {
                        if (!char.IsDigit(chars[k])) break;

                        number += chars[k];
                        lastIndex = k;
                    }

                    // All possible coordinates for this number
                    var possibleCoordinates = new List<Coordinate>();

                    // DIAGONAL FIRST
                    possibleCoordinates.Add(new Coordinate(i + 1, firstIndex - 1));
                    possibleCoordinates.Add(new Coordinate(i - 1, firstIndex - 1));

                    // DIAGONAL LAST
                    possibleCoordinates.Add(new Coordinate(i + 1, lastIndex + 1));
                    possibleCoordinates.Add(new Coordinate(i - 1, lastIndex + 1));

                    // HORIZONTAL 
                    possibleCoordinates.Add(new Coordinate(i, firstIndex - 1));
                    possibleCoordinates.Add(new Coordinate(i, lastIndex + 1));

                    // VERTICAL FIRST
                    possibleCoordinates.Add(new Coordinate(i + 1, firstIndex));
                    possibleCoordinates.Add(new Coordinate(i - 1, firstIndex));

                    // VERTICAL LAST
                    possibleCoordinates.Add(new Coordinate(i - 1, lastIndex));
                    possibleCoordinates.Add(new Coordinate(i + 1, lastIndex));

                    // VERTICAL MIDDLE
                    for (var c = 1; c < number.Length; c++)
                    {
                        possibleCoordinates.Add(new Coordinate(i + 1, firstIndex + c));
                        possibleCoordinates.Add(new Coordinate(i - 1, firstIndex + c));
                    }

                    if (coordinates.Any(x => possibleCoordinates.Contains(x)))
                    {
                        validNumbers.Add(int.Parse(number));
                    }

                    j = lastIndex;
                }
            }
        }


        return validNumbers.Sum();
    }

    public static long PartTwo(string[] input)
    {
        var asteriskNeighbours = new Dictionary<Coordinate, List<int>>();

        for (var i = 0; i < input.Length; i++)
        {
            var chars = input[i].ToCharArray();

            for (var j = 0;
                 j < chars.Length;
                 j++)
            {
                if (chars[j] == '*')
                {
                    asteriskNeighbours.Add(new Coordinate(i, j), []);
                }
            }
        }

        for (var i = 0; i < input.Length; i++)
        {
            var chars = input[i].ToCharArray();

            for (var j = 0;
                 j < chars.Length;
                 j++)
            {
                if (char.IsDigit(chars[j]))
                {
                    var firstIndex = j;
                    var lastIndex = j;
                    var number = chars[j].ToString();
                    for (int k = j + 1; k < chars.Length; k++)
                    {
                        if (!char.IsDigit(chars[k])) break;

                        number += chars[k];
                        lastIndex = k;
                    }

                    // All possible coordinates for this number
                    var possibleCoordinates = new List<Coordinate>();

                    // DIAGONAL FIRST
                    possibleCoordinates.Add(new Coordinate(i + 1, firstIndex - 1));
                    possibleCoordinates.Add(new Coordinate(i - 1, firstIndex - 1));

                    // DIAGONAL LAST
                    possibleCoordinates.Add(new Coordinate(i + 1, lastIndex + 1));
                    possibleCoordinates.Add(new Coordinate(i - 1, lastIndex + 1));

                    // HORIZONTAL 
                    possibleCoordinates.Add(new Coordinate(i, firstIndex - 1));
                    possibleCoordinates.Add(new Coordinate(i, lastIndex + 1));

                    // VERTICAL FIRST
                    possibleCoordinates.Add(new Coordinate(i + 1, firstIndex));
                    possibleCoordinates.Add(new Coordinate(i - 1, firstIndex));

                    // VERTICAL LAST
                    possibleCoordinates.Add(new Coordinate(i - 1, lastIndex));
                    possibleCoordinates.Add(new Coordinate(i + 1, lastIndex));

                    // VERTICAL MIDDLE
                    for (var c = 1; c < number.Length; c++)
                    {
                        possibleCoordinates.Add(new Coordinate(i + 1, firstIndex + c));
                        possibleCoordinates.Add(new Coordinate(i - 1, firstIndex + c));
                    }

                    foreach (var coordinate in possibleCoordinates)
                    {
                        if (asteriskNeighbours.ContainsKey(coordinate))
                        {
                            asteriskNeighbours[coordinate].Add(int.Parse(number));
                            break;
                        }
                    }

                    j = lastIndex;
                }
            }
        }


        var result = asteriskNeighbours
            .Where(x => x.Value.Count > 1)
            .Select(x => x.Value.Slice(x.Value.Count - 2, 2));


        return result.Sum(x => x[0] * x[1]);
    }
}

public record struct Coordinate(int X, int Y);