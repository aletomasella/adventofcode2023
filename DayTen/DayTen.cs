namespace dotnet_aoc.DayTen;

public static class DayTen
{
    public static long PartOne(string[] inputs)
    {
        var input = @".....
                                .S-7.
                                .|.|.
                                .L-J.
                                .....".Split('\n');


        var directions = new Dictionary<char, (int, int)>();

        directions.Add('|', (0, 1));
        directions.Add('-', (1, 0));


        return 0;
    }

    public static long PartTwo(string[] input)
    {
        return 0;
    }
}