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
        var input = @"LR

11A = (11B, XXX)
11B = (XXX, 11Z)
11Z = (11B, XXX)
22A = (22B, XXX)
22B = (22C, 22C)
22C = (22Z, 22Z)
22Z = (22B, 22B)
XXX = (XXX, XXX)";

        Assert.Equal(6, DayEight.PartTwo(input.Split('\n')));
    }
}