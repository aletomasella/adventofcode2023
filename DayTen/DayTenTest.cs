using Xunit;

namespace dotnet_aoc.DayTen;

public class DayTenTest
{
    [Fact]
    public void PartOne()
    {
        var input = @".....
.S-7.
.|.|.
.L-J.
.....";
        Assert.Equal(4, DayTen.PartOne(input.Split('\n')));

        input = @"..F7.
.FJ|.
SJ.L7
|F--J
LJ...";

        Assert.Equal(8, DayTen.PartOne(input.Split('\n')));
    }


//     [Fact]
//     public void PartTwo()
//     {
//         var input = @".....
// .S-7.
// .|.|.
// .L-J.
// .....";
//         Assert.Equal(8, DayTen.PartTwo(input));
//     }
}