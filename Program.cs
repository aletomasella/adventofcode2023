// See https://aka.ms/new-console-template for more information


using dotnet_aoc.DayOne;
using dotnet_aoc.DayTwo;

// DAY ONE ADVENT OF CODE
var fileInputOne = new StreamReader("./DayOne/input.txt");

var input = fileInputOne.ReadToEnd();

var resultDayOnePartOne = DayOne.PartOne(input.Split('\n'));
Console.WriteLine($"Day One Part One: {resultDayOnePartOne}");

var resultDayOnePartTwo = DayOne.PartTwo(input.Split('\n'));
Console.WriteLine($"Day One Part Two: {resultDayOnePartTwo}");

// DAY TWO ADVENT OF CODE

var fileInputTwo = new StreamReader("./DayTwo/input.txt");

var inputTwo = fileInputTwo.ReadToEnd();

var resultDayTwoPartOne = DayTwo.PartOne(inputTwo.Split('\n'));

Console.WriteLine($"Day Two Part One: {resultDayTwoPartOne}");

var resultDayTwoPartTwo = DayTwo.PartTwo(inputTwo.Split('\n'));

Console.WriteLine($"Day Two Part Two: {resultDayTwoPartTwo}");

// DAY THREE ADVENT OF CODE