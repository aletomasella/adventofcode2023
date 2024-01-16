namespace dotnet_aoc.DayEight;

public static class DayEight
{
    public static int PartOne(string[] input)
    {
        var instruction = input[0].ToCharArray();

        var nodesDictionary = new Dictionary<string, (string, string)>();


        for (var i = 2; i < input.Length; i++)
        {
            var node = input[i].Split(" = ");
            var nodeValue = node[1].Replace("(", "").Replace(")", "").Split(", ");
            nodesDictionary.Add(node[0], (nodeValue[0], nodeValue[1]));
        }

        // foreach (var c in instruction)
        // {
        //     Console.WriteLine(c);
        // }
        //
        // foreach (var node in nodesDictionary)
        // {
        //     Console.WriteLine($"{node.Key} - {node.Value.Item1} - {node.Value.Item2}");
        // }

        var currentNode = nodesDictionary["AAA"];

        var target = nodesDictionary["ZZZ"];

        var instructionIndex = 0;

        var steps = 0;


        while (currentNode != target)
        {
            if (instructionIndex >= instruction.Length)
                instructionIndex = 0;

            if (instruction[instructionIndex] == 'R')
            {
                currentNode = nodesDictionary[currentNode.Item2];
            }
            else
            {
                currentNode = nodesDictionary[currentNode.Item1];
            }

            instructionIndex++;
            steps++;
        }

        return steps;
    }

    public static int PartTwo(string[] inputs)
    {
        var input = @"".Split('\n');

        return 0;
    }
}