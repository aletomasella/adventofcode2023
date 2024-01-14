using Xunit;

namespace dotnet_aoc.DaySeven;

public class DaySevenTest
{
    [Fact]
    public void PartOne()
    {
        var input = @"32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483";

        Assert.Equal(6440, DaySeven.PartOne(input.Split('\n')));
    }

    [Fact]
    public void PartTwo()
    {
        var input = @"32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483";


        Assert.Equal(0, DaySeven.PartTwo(input.Split('\n')));
    }
}