using Xunit;

namespace dotnet_aoc.DayNine;

public class DayNineTest
{
    [Fact]
    public void PartOne()
    {
        var input = @"10  13  16  21  30  45  68
   3   3   5   9  15  23
     0   2   4   6   8
       2   2   2   2
         0   0   0";

        Assert.Equal(127, DayNine.PartOne(input.Split('\n')));
    }


    [Fact]
    public void PartTwo()
    {
        var input = @"10  13  16  21  30  45  68
   3   3   5   9  15  23
     0   2   4   6   8
       2   2   2   2
         0   0   0";

        Assert.Equal(62, DayNine.PartTwo(input.Split('\n')));
    }
}