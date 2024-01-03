using Xunit;

namespace dotnet_aoc.DayThree;

public static class DayThreeTest
{
    [Fact]
    public static void PartOne()
    {
        var input = @"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..";


        Assert.Equal(4361, DayThree.PartOne(input.Split('\n')));
    }

    [Fact]
    public static void PartTwo()
    {
        var input = new[]
        {
            "R8,U5,L5,D3",
            "U7,R6,D4,L4"
        };
        Assert.Equal(30, DayThree.PartTwo(input));
    }
}