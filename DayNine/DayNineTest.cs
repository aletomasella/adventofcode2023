using Xunit;

namespace dotnet_aoc.DayNine;

public class DayNineTest
{
    [Fact]
    public void PartOne()
    {
        var input = @"0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45";

        Assert.Equal(114, DayNine.PartOne(input.Split('\n')));
    }


    [Fact]
    public void PartTwo()
    {
        var input = @"0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45";

        Assert.Equal(2, DayNine.PartTwo(input.Split('\n')));
    }
}