namespace dotnet_aoc.DayOne;

using Xunit;

public class DayOneTest
{
    [Theory]
    [InlineData(@"1abc2
                       pqr3stu8vwx
                       a1b2c3d4e5f
                       treb7uchet",
        142)]
    public static void TestPartOne(string input, int expected)
    {
        var result = DayOne.PartOne(input.Split('\n'));

        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData(@"two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen",
        281)]
    public static void TestPartTwo(string input, int expected)
    {
        var result = DayOne.PartTwo(input.Split('\n'));
        Assert.Equal(expected, result);
    }
}