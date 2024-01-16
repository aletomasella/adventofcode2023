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
        var input = @"LR

11A = (11B, XXX)
11B = (XXX, 11Z)
11Z = (11B, XXX)
22A = (22B, XXX)
22B = (22C, 22C)
22C = (22Z, 22Z)
22Z = (22B, 22B)
XXX = (XXX, XXX)".Split('\n');

        var instruction = input[0].ToCharArray();

        var nodesDictionary = new Dictionary<string, (string, string)>();


        for (var i = 2; i < input.Length; i++)
        {
            var node = input[i].Split(" = ");
            var nodeValue = node[1].Replace("(", "").Replace(")", "").Split(", ");
            nodesDictionary.Add(node[0], (nodeValue[0], nodeValue[1]));
        }

        var startingNodesToTraverseSimultaneously = nodesDictionary.Where(x => x.Key.EndsWith('A')).ToArray();

        // foreach (var c in instruction)
        // {
        //     Console.WriteLine(c);
        // }
        //
        // foreach (var node in nodesDictionary)
        // {
        //     Console.WriteLine($"{node.Key} - {node.Value.Item1} - {node.Value.Item2}");
        // }

        var instructionIndex = 0;


        var stepsForEachNode = new Dictionary<string, (int, char)>();

        foreach (var node in startingNodesToTraverseSimultaneously)
        {
            stepsForEachNode.Add(node.Key, (0, 'A'));
        }

        while (true)
        {
            if (instructionIndex >= instruction.Length)
                instructionIndex = 0;

            foreach (var node in startingNodesToTraverseSimultaneously)
            {
                var currentNode = nodesDictionary[node.Key];

                if (instruction[instructionIndex] == 'R')
                {
                    if (currentNode.Item2.EndsWith('Z'))
                    {
                        // LAST CHAR OF CURRENT NODE IS Z
                        stepsForEachNode[node.Key] = (stepsForEachNode[node.Key].Item1 + 1, 'Z');
                        break;
                    }


                    stepsForEachNode[node.Key] = (stepsForEachNode[node.Key].Item1 + 1,
                        currentNode.Item2[^1]);
                    currentNode = nodesDictionary[currentNode.Item2];
                }
                else
                {
                    if (currentNode.Item1.EndsWith('Z'))
                    {
                        stepsForEachNode[node.Key] = (stepsForEachNode[node.Key].Item1 + 1, 'Z');
                        break;
                    }

                    stepsForEachNode[node.Key] = (stepsForEachNode[node.Key].Item1 + 1,
                        currentNode.Item1[^1]);
                    currentNode = nodesDictionary[currentNode.Item1];
                }
            }

            foreach (var data in stepsForEachNode)
            {
                Console.WriteLine($"KEY {data.Key} - VALUE {data.Value.Item1} - {data.Value.Item2}");
            }

            if (stepsForEachNode.All(x => x.Value.Item2 == stepsForEachNode.First().Value.Item2))
            {
                break;
            }

            instructionIndex++;
        }

        return stepsForEachNode.First().Value.Item1;
    }
}