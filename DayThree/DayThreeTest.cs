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
        Assert.Equal(467835, DayThree.PartTwo(input.Split('\n')));
    }
}