// See https://aka.ms/new-console-template for more information


using dotnet_aoc.DayOne;

// DAY ONE ADVENT OF CODE
var fileInputOne = new StreamReader("./DayOne/input.txt");

var input = fileInputOne.ReadToEnd();

var resultDayOnePartOne = DayOne.PartOne(input.Split('\n'));
Console.WriteLine($"Day One Part One: {resultDayOnePartOne}");

var resultDayOnePartTwo = DayOne.PartTwo(input.Split('\n'));
Console.WriteLine($"Day One Part Two: {resultDayOnePartTwo}");

// DAY TWO ADVENT OF CODE