using Xunit;

namespace dotnet_aoc.DaySix;

public class DaySixTest
{
    [Fact]
    public void PartOne()
    {
        var input = @"Time:      7  15   30
                      Distance:  9  40  200";

        Assert.Equal(288, DaySix.PartOne(input.Split('\n')));
    }

    [Fact]
    public void PartTwo()
    {
        var input = @"Time:      7  15   30
                      Distance:  9  40  200";

        Assert.Equal(71503, DaySix.PartTwo(input.Split('\n')));
    }
}