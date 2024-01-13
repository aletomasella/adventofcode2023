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
}