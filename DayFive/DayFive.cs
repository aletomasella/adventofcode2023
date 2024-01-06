namespace dotnet_aoc.DayFive;

public static class DayFive
{
    public static long PartOne(string[] inputs)
    {
        var input = @"seeds: 79 14 55 13

seed-to-soil map:
50 98 2
52 50 48

soil-to-fertilizer map:
0 15 37
37 52 2
39 0 15

fertilizer-to-water map:
49 53 8
0 11 42
42 0 7
57 7 4

water-to-light map:
88 18 7
18 25 70

light-to-temperature map:
45 77 23
81 45 19
68 64 13

temperature-to-humidity map:
0 69 1
1 0 69

humidity-to-location map:
60 56 37
56 93 4".Split('\n');

        var allSeeds = new Dictionary<long, Seed>();

        for (var i = 0; i < input.Length; i++)
        {
            var line = input[i];

            if (line.Trim() == String.Empty) continue;
            Console.WriteLine(line);

            if (line.StartsWith("seeds:"))
            {
                var seeds = line.Split(":")[1].Split(' ').Where(x => x.Trim() != String.Empty)
                    .Select(x => long.Parse(x.Trim()))
                    .ToList();

                foreach (var seed in seeds)
                {
                    if (!allSeeds.ContainsKey(seed))
                        allSeeds.Add(seed, new Seed(seed));
                }

                continue;
            }

            if (line.Contains("seed-to-soil"))
            {
                for (var j = i + 1; j < input.Length; j++)
                {
                    var mapLine = input[j];
                    if (mapLine.Trim() == String.Empty)
                    {
                        i = j;
                        break;
                    }

                    // 0 => SOIL IDs | 1 => SEED IDs | 2 => LENGTH
                    var data = mapLine.Split(" ").Select(long.Parse).ToList();
                    for (var k = data[1]; k <= data[1] + data[2]; k++)
                    {
                        if (allSeeds.ContainsKey(k))
                        {
                            var seed = allSeeds[k];
                            seed.Soil = data[0];
                        }

                        data[0] += 1;
                    }
                }

                continue;
            }

            if (line.Contains("soil-to-fertilizer"))
            {
                // Same as above
                for (var j = i + 1; j < input.Length; j++)
                {
                    var mapLine = input[j];

                    if (mapLine.Trim() == String.Empty)
                    {
                        i = j;
                        break;
                    }

                    // 0 => FERTILIZER IDs | 1 => SOIL IDs | 2 => LENGTH
                    var data = mapLine.Split(" ").Select(long.Parse).ToList();
                    for (long k = data[1]; k <= data[1] + data[2]; k++)
                    {
                        var seed = allSeeds.Where(x => x.Value.Soil == k).ToArray();

                        var mappedSeeds = new List<Seed>();

                        if (seed.Length > 0)
                        {
                            foreach (var s in seed)
                            {
                                s.Value.Fertilazer = data[0];
                                mappedSeeds.Add(s.Value);
                            }
                        }

                        foreach (var s in allSeeds)
                        {
                            if (mappedSeeds.Contains(s.Value)) continue;
                            s.Value.Fertilazer = s.Value.Soil;
                        }

                        data[0] += 1;
                    }
                }

                if (line.StartsWith("fertilizer-to-water map:"))
                {
                    // Same as above
                    for (var j = i + 1; j < input.Length; j++)
                    {
                        var mapLine = input[j];
                        if (mapLine.Trim() == String.Empty)
                        {
                            i = j;
                            break;
                        }

                        // 0 => WATER IDs | 1 => FERTILIZER IDs | 2 => LENGTH
                        var data = mapLine.Split(" ").Select(long.Parse).ToList();
                        for (long k = data[1]; k < data[1] + data[2]; k++)
                        {
                            var seed = allSeeds.Where(x => x.Value.Fertilazer == k).ToArray();
                            var mappedSeeds = new List<Seed>();

                            if (seed.Length > 0)
                            {
                                foreach (var s in seed)
                                {
                                    s.Value.Water = data[0];
                                    mappedSeeds.Add(s.Value);
                                }
                            }

                            foreach (var s in allSeeds)
                            {
                                if (mappedSeeds.Contains(s.Value)) continue;
                                s.Value.Water = s.Value.Fertilazer;
                            }

                            data[0] += 1;
                        }
                    }

                    if (line.StartsWith("water-to-light map:"))
                    {
                        // Same as above
                        for (var j = i + 1; j < input.Length; j++)
                        {
                            var mapLine = input[j];
                            if (mapLine.Trim() == String.Empty)
                            {
                                i = j;
                                break;
                            }

                            // 0 => LIGHT IDs | 1 => WATER IDs | 2 => LENGTH
                            var data = mapLine.Split(" ").Select(long.Parse).ToList();
                            for (long k = data[1]; k < data[1] + data[2]; k++)
                            {
                                var seed = allSeeds.Where(x => x.Value.Water == k).ToArray();

                                var mappedSeeds = new List<Seed>();

                                if (seed.Length > 0)
                                {
                                    foreach (var s in seed)
                                    {
                                        s.Value.Light = data[0];
                                        mappedSeeds.Add(s.Value);
                                    }
                                }

                                foreach (var s in allSeeds)
                                {
                                    if (mappedSeeds.Contains(s.Value)) continue;
                                    s.Value.Light = s.Value.Water;
                                }

                                data[0] += 1;
                            }
                        }

                        if (line.StartsWith("light-to-temperature map:"))
                        {
                            // Same as above
                            for (var j = i + 1; j < input.Length; j++)
                            {
                                var mapLine = input[j];
                                if (mapLine.Trim() == String.Empty)
                                {
                                    i = j;
                                    break;
                                }

                                // 0 => TEMPERATURE IDs | 1 => LIGHT IDs | 2 => LENGTH
                                var data = mapLine.Split(" ").Select(long.Parse).ToList();
                                var mappedSeeds = new List<Seed>();
                                for (long k = data[1]; k < data[1] + data[2]; k++)
                                {
                                    var seed = allSeeds.Where(x => x.Value.Light == k).ToArray();

                                    if (seed.Length > 0)
                                    {
                                        foreach (var s in seed)
                                        {
                                            s.Value.Temperature = data[0];
                                            mappedSeeds.Add(s.Value);
                                        }
                                    }


                                    data[0] += 1;
                                }

                                foreach (var s in allSeeds)
                                {
                                    if (mappedSeeds.Contains(s.Value)) continue;
                                    s.Value.Temperature = s.Value.Light;
                                }
                            }
                        }

                        if (line.StartsWith("temperature-to-humidity map:"))
                        {
                            var mappedSeeds = new List<Seed>();
                            // Same as above
                            for (var j = i + 1; j < input.Length; j++)
                            {
                                var mapLine = input[j];
                                if (mapLine.Trim() == String.Empty)
                                {
                                    i = j;
                                    break;
                                }

                                // 0 => HUMIDITY IDs | 1 => TEMPERATURE IDs | 2 => LENGTH
                                var data = mapLine.Split(" ").Select(long.Parse).ToList();
                                for (long k = data[1]; k < data[1] + data[2]; k++)
                                {
                                    var seed = allSeeds.Where(x => x.Value.Temperature == k).ToArray();

                                    if (seed.Length > 0)
                                    {
                                        foreach (var s in seed)
                                        {
                                            s.Value.Humidity = data[0];
                                        }
                                    }

                                    data[0] += 1;
                                }
                            }
                        }

                        if (line.StartsWith("humidity-to-location map:"))
                        {
                            // Same as above
                            for (var j = i + 1; j < input.Length; j++)
                            {
                                var mapLine = input[j];
                                if (mapLine.Trim() == String.Empty)
                                {
                                    i = j + 1;
                                    break;
                                }

                                // 0 => LOCATION IDs | 1 => HUMIDITY IDs | 2 => LENGTH
                                var data = mapLine.Split(" ").Select(long.Parse).ToList();
                                for (long k = data[1]; k < data[1] + data[2]; k++)
                                {
                                    var seed = allSeeds.Where(x => x.Value.Humidity == k).ToArray();

                                    if (seed.Length > 0)
                                    {
                                        foreach (var s in seed)
                                        {
                                            s.Value.Location = data[0];
                                        }
                                    }

                                    data[0] += 1;
                                }
                            }
                        }
                    }
                }
            }
        }

        foreach (var seed in allSeeds)
        {
            Console.WriteLine(
                $"Seed: {seed.Value.Id} | Soil: {seed.Value.Soil} | Fertilizer: {seed.Value.Fertilazer} | Water: {seed.Value.Water} | Light: {seed.Value.Light} | Temperature: {seed.Value.Temperature} | Humidity: {seed.Value.Humidity} | Location: {seed.Value.Location}");
        }

        // Select Min Location Id from allSeeds
        var result = allSeeds.OrderBy(x => x.Value.Location).First();


        return result.Value.Id;
    }

    public static long PartTwo(string[] input)
    {
        var result = 0;

        return result;
    }
}

public class Seed
{
    public long Id;
    public long Soil { get; set; }
    public long Fertilazer { get; set; }
    public long Water { get; set; }
    public long Light { get; set; }
    public long Temperature { get; set; }
    public long Humidity { get; set; }
    public long Location { get; set; }

    public Seed(long id)
    {
        this.Id = id;
        this.Soil = id;
        this.Fertilazer = id;
        this.Water = id;
        this.Light = id;
        this.Temperature = id;
        this.Humidity = id;
        this.Location = id;
    }
}