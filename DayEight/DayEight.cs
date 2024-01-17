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

    public static ulong PartTwo(string[] input)
    {
//         var input = @"LR
//
// 11A = (11B, XXX)
// 11B = (XXX, 11Z)
// 11Z = (11B, XXX)
// 22A = (22B, XXX)
// 22B = (22C, 22C)
// 22C = (22Z, 22Z)
// 22Z = (22B, 22B)
// XXX = (XXX, XXX)".Split('\n');

        var instructions = input[0].ToCharArray();

        var nodes = new Dictionary<string, Node>();


        for (var i = 2; i < input.Length; i++)
        {
            var nodeData = input[i].Split(" = ");
            var nodeValue = nodeData[1].Replace("(", "").Replace(")", "").Split(", ");

            var node = new Node(nodeData[0], nodeValue[0], nodeValue[1]);
            nodes[nodeData[0]] = node;
        }

        long steps = 0;
        var cycleSizes = new List<ulong>();

        var startingNodes = new List<string>(nodes.Keys.Where(k => k.EndsWith('A')));
        foreach (var startingNode in startingNodes)
        {
            steps = 0;
            var currentNode = startingNode;
            var currentInstruction = 0;
            while (!currentNode.EndsWith('Z'))
            {
                var instruction = instructions[currentInstruction];
                steps++;

                var node = nodes[currentNode];
                if (instruction == 'L')
                {
                    currentNode = node.Left;
                }
                else
                {
                    currentNode = node.Right;
                }

                currentInstruction++;
                currentInstruction %= instructions.Length;
            }

            cycleSizes.Add((ulong)steps);
        }

        var lcm = cycleSizes[0];
        for (int i = 1; i < cycleSizes.Count; i++)
        {
            lcm = LowestCommonMultiple(lcm, cycleSizes[i]);
        }

        Console.WriteLine(lcm);

        ulong LowestCommonMultiple(ulong a, ulong b)
        {
            return a * b / GreatestCommonDivisor(a, b);
        }

        ulong GreatestCommonDivisor(ulong a, ulong b)
        {
            while (b != 0)
            {
                var t = b;
                b = a % b;
                a = t;
            }

            return a;
        }

        return lcm;
    }
}

record Node(string Name, string Left, string Right);