// See https://aka.ms/new-console-template for more information


using dotnet_aoc.DayFour;
using dotnet_aoc.DayOne;
using dotnet_aoc.DayThree;
using dotnet_aoc.DayTwo;

// // DAY ONE ADVENT OF CODE
// Console.WriteLine("DAY ONE ADVENT OF CODE");
// var fileInputOne = new StreamReader("./DayOne/input.txt");
//
// var input = fileInputOne.ReadToEnd();
//
// var resultDayOnePartOne = DayOne.PartOne(input.Split('\n'));
// Console.WriteLine($"Day One Part One: {resultDayOnePartOne}");
//
// var resultDayOnePartTwo = DayOne.PartTwo(input.Split('\n'));
// Console.WriteLine($"Day One Part Two: {resultDayOnePartTwo}");
//
// // DAY TWO ADVENT OF CODE
// Console.WriteLine("DAY TWO ADVENT OF CODE");
// var fileInputTwo = new StreamReader("./DayTwo/input.txt");
//
// var inputTwo = fileInputTwo.ReadToEnd();
//
// var resultDayTwoPartOne = DayTwo.PartOne(inputTwo.Split('\n'));
//
// Console.WriteLine($"Day Two Part One: {resultDayTwoPartOne}");
//
// var resultDayTwoPartTwo = DayTwo.PartTwo(inputTwo.Split('\n'));
//
// Console.WriteLine($"Day Two Part Two: {resultDayTwoPartTwo}");

// DAY THREE ADVENT OF CODE
// Console.WriteLine("DAY THREE ADVENT OF CODE");
// var fileInputThree = new StreamReader("./DayThree/input.txt");
//
// var inputThree = fileInputThree.ReadToEnd();
//
// var resultDayThreePartOne = DayThree.PartOne(inputThree.Split('\n'));
//
// Console.WriteLine($"Day Three Part One: {resultDayThreePartOne}");
//
// var resultDayThreePartTwo = DayThree.PartTwo(inputThree.Split('\n'));
//
// Console.WriteLine($"Day Three Part Two: {resultDayThreePartTwo}");

// DAY FOUR ADVENT OF CODE
Console.WriteLine("DAY FOUR ADVENT OF CODE");
var fileInputFour = new StreamReader("./DayFour/input.txt");

var inputFour = fileInputFour.ReadToEnd();

var resultDayFourPartOne = DayFour.PartOne(inputFour.Split('\n'));
//
Console.WriteLine($"Day Four Part One: {resultDayFourPartOne}");

//
var resultDayFourPartTwo = DayFour.PartTwo(inputFour.Split('\n'));
//
Console.WriteLine($"Day Four Part Two: {resultDayFourPartTwo}");

// DAY FIVE ADVENT OF CODE