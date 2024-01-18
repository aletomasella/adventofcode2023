using Xunit;

namespace dotnet_aoc.DayNine;

public class DayNineTest
{
    [Fact]
    public void PartOne()
    {
        var input = new[]
        {
            "35",
            "20",
            "15",
            "25",
            "47",
            "40",
            "62",
            "55",
            "65",
            "95",
            "102",
            "117",
            "150",
            "182",
            "127",
            "219",
            "299",
            "277",
            "309",
            "576"
        };

        Assert.Equal(127, DayNine.PartOne(input));
    }


    [Fact]
    public void PartTwo()
    {
        var input = new[]
        {
            "35",
            "20",
            "15",
            "25",
            "47",
            "40",
            "62",
            "55",
            "65",
            "95",
            "102",
            "117",
            "150",
            "182",
            "127",
            "219",
            "299",
            "277",
            "309",
            "576"
        };

        Assert.Equal(62, DayNine.PartTwo(input));
    }
}