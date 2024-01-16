using Xunit;

namespace dotnet_aoc.DayEight;

public class DayEightTest
{
    [Fact]
    public void PartOne()
    {
        var input = @"RL

AAA = (BBB, CCC)
BBB = (DDD, EEE)
CCC = (ZZZ, GGG)
DDD = (DDD, DDD)
EEE = (EEE, EEE)
GGG = (GGG, GGG)
ZZZ = (ZZZ, ZZZ)";

        Assert.Equal(2, DayEight.PartOne(input.Split('\n')));

        input = @"LLR

AAA = (BBB, BBB)
BBB = (AAA, ZZZ)
ZZZ = (ZZZ, ZZZ)";

        Assert.Equal(6, DayEight.PartOne(input.Split('\n')));
    }

    [Fact]
    public void PartTwo()
    {
        var input = @"";

        Assert.Equal(8, DayEight.PartTwo(input.Split('\n')));
    }
}