namespace dotnet_aoc.DayFive;

public static class DayFive
{
    public static long PartOne(string[] input)
    {
        var allSeeds = new Dictionary<long, Seed>();

        for (var i = 0; i < input.Length; i++)
        {
            Console.WriteLine($"LINEA NRO: {i} | {input[i]}");
            var line = input[i];

            if (line.Trim() == String.Empty) continue;

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
                    var seedsFound = allSeeds.Where(x => x.Key >= data[1] && x.Key <= data[1] + data[2])
                        .Aggregate(new Dictionary<long, Seed>(), (acc, x) =>
                        {
                            acc.Add(x.Key, x.Value);
                            return acc;
                        });

                    for (var k = data[1]; k <= data[1] + data[2]; k++)
                    {
                        if (seedsFound.ContainsKey(k))
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
                var notMappedKeys = allSeeds.Select(x => x.Key).ToList();

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

                    var soilsFound = allSeeds.Where(x => x.Value.Soil >= data[1] && x.Value.Soil <= data[1] + data[2])
                        .Aggregate(new Dictionary<long, Seed>(), (acc, x) =>
                        {
                            acc.Add(x.Value.Soil, x.Value);
                            return acc;
                        });

                    if (soilsFound.Count == 0) continue;


                    for (long k = data[1]; k <= data[1] + data[2]; k++)
                    {
                        if (soilsFound.ContainsKey(k))
                        {
                            allSeeds[soilsFound[k].Id].Fertilazer = data[0];
                            notMappedKeys.Remove(soilsFound[k].Id);
                        }


                        data[0] += 1;
                    }
                }

                foreach (var s in notMappedKeys)
                {
                    allSeeds[s].Fertilazer = allSeeds[s].Soil;
                }

                continue;
            }

            if (line.StartsWith("fertilizer-to-water map:"))
            {
                var notMappedKeys = allSeeds.Select(x => x.Key).ToList();


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

                    var fertilizersFound = allSeeds.Where(x =>
                            x.Value.Fertilazer >= data[1] && x.Value.Fertilazer <= data[1] + data[2])
                        .Aggregate(new Dictionary<long, Seed>(), (acc, x) =>
                        {
                            acc.Add(x.Value.Fertilazer, x.Value);
                            return acc;
                        });


                    for (long k = data[1]; k < data[1] + data[2]; k++)
                    {
                        if (fertilizersFound.ContainsKey(k))
                        {
                            allSeeds[fertilizersFound[k].Id].Water = data[0];
                            notMappedKeys.Remove(fertilizersFound[k].Id);
                        }


                        data[0] += 1;
                    }
                }

                foreach (var s in notMappedKeys)
                {
                    allSeeds[s].Water = allSeeds[s].Fertilazer;
                }

                continue;
            }

            if (line.StartsWith("water-to-light map:"))
            {
                var notMappedKeys = allSeeds.Select(x => x.Key).ToList();

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

                    var waterFound = allSeeds.Where(x => x.Value.Water >= data[1] && x.Value.Water <= data[1] + data[2])
                        .Aggregate(new Dictionary<long, Seed>(), (acc, x) =>
                        {
                            acc.Add(x.Value.Water, x.Value);
                            return acc;
                        });

                    for (long k = data[1]; k < data[1] + data[2]; k++)
                    {
                        if (waterFound.ContainsKey(k))
                        {
                            allSeeds[waterFound[k].Id].Light = data[0];
                            notMappedKeys.Remove(waterFound[k].Id);
                        }


                        data[0] += 1;
                    }
                }

                foreach (var s in notMappedKeys)
                {
                    allSeeds[s].Light = allSeeds[s].Water;
                }

                continue;
            }

            if (line.StartsWith("light-to-temperature map:"))
            {
                var notMappedKeys = allSeeds.Select(x => x.Key).ToList();


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

                    var lightFound = allSeeds.Where(x => x.Value.Light >= data[1] && x.Value.Light <= data[1] + data[2])
                        .Aggregate(new Dictionary<long, Seed>(), (acc, x) =>
                        {
                            acc.Add(x.Value.Light, x.Value);
                            return acc;
                        });

                    for (long k = data[1]; k < data[1] + data[2]; k++)
                    {
                        if (lightFound.ContainsKey(k))
                        {
                            allSeeds[lightFound[k].Id].Temperature = data[0];
                            notMappedKeys.Remove(lightFound[k].Id);
                        }


                        data[0] += 1;
                    }
                }

                foreach (var s in notMappedKeys)
                {
                    allSeeds[s].Temperature = allSeeds[s].Light;
                }

                continue;
            }

            if (line.StartsWith("temperature-to-humidity map:"))
            {
                var notMappedKeys = allSeeds.Select(x => x.Key).ToList();

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

                    var temperatureFound = allSeeds.Where(x =>
                            x.Value.Temperature >= data[1] && x.Value.Temperature <= data[1] + data[2])
                        .Aggregate(new Dictionary<long, Seed>(), (acc, x) =>
                        {
                            acc.Add(x.Value.Temperature, x.Value);
                            return acc;
                        });

                    for (long k = data[1]; k < data[1] + data[2]; k++)
                    {
                        if (temperatureFound.ContainsKey(k))
                        {
                            allSeeds[temperatureFound[k].Id].Humidity = data[0];
                            notMappedKeys.Remove(temperatureFound[k].Id);
                        }


                        data[0] += 1;
                    }
                }

                foreach (var s in notMappedKeys)
                {
                    allSeeds[s].Humidity = allSeeds[s].Temperature;
                }

                continue;
            }

            if (line.StartsWith("humidity-to-location map:"))
            {
                var notMappedKeys = allSeeds.Select(x => x.Key).ToList();

                // Same as above
                for (var j = i + 1; j < input.Length; j++)
                {
                    var mapLine = input[j];
                    if (mapLine.Trim() == String.Empty)
                    {
                        i = j;
                        break;
                    }

                    // 0 => LOCATION IDs | 1 => HUMIDITY IDs | 2 => LENGTH
                    var data = mapLine.Split(" ").Select(long.Parse).ToList();

                    var humidityFound = allSeeds
                        .Where(x => x.Value.Humidity >= data[1] && x.Value.Humidity <= data[1] + data[2])
                        .Aggregate(new Dictionary<long, Seed>(), (acc, x) =>
                        {
                            acc.Add(x.Value.Humidity, x.Value);
                            return acc;
                        });

                    for (long k = data[1]; k < data[1] + data[2]; k++)
                    {
                        if (humidityFound.ContainsKey(k))
                        {
                            allSeeds[humidityFound[k].Id].Location = data[0];
                            notMappedKeys.Remove(humidityFound[k].Id);
                        }


                        data[0] += 1;
                    }
                }

                foreach (var s in notMappedKeys)
                {
                    allSeeds[s].Location = allSeeds[s].Humidity;
                }
            }
        }

        // foreach (var seed in allSeeds)
        // {
        //     Console.WriteLine(
        //         $"Seed: {seed.Value.Id} | Soil: {seed.Value.Soil} | Fertilizer: {seed.Value.Fertilazer} | Water: {seed.Value.Water} | Light: {seed.Value.Light} | Temperature: {seed.Value.Temperature} | Humidity: {seed.Value.Humidity} | Location: {seed.Value.Location}");
        // }

// Select Min Location Id from allSeeds
        var result = allSeeds.OrderBy(x => x.Value.Location).First();
        return result.Value.Location;
    }


    public static long PartTwo(string[] input)
    {
        var allSeeds = new Dictionary<long, Seed>();

        for (var i = 0; i < input.Length; i++)
        {
            Console.WriteLine($"LINEA NRO: {i} | {input[i]}");
            var line = input[i];

            if (line.Trim() == String.Empty) continue;

            if (line.StartsWith("seeds:"))
            {
                var seeds = line.Split(":")[1].Split(' ').Where(x => x.Trim() != String.Empty)
                    .Select(x => long.Parse(x.Trim()))
                    .ToList();

                for (var j = 0; j < seeds.Count; j += 2)
                {
                    var seed = seeds[j];
                    var range = seeds[j + 1];

                    for (var k = seed; k <= seed + range; k++)
                    {
                        if (!allSeeds.ContainsKey(k))
                            allSeeds.Add(k, new Seed(k));
                    }
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
                    var seedsFound = allSeeds.Where(x => x.Key >= data[1] && x.Key <= data[1] + data[2])
                        .Aggregate(new Dictionary<long, Seed>(), (acc, x) =>
                        {
                            acc.Add(x.Key, x.Value);
                            return acc;
                        });

                    for (var k = data[1]; k <= data[1] + data[2]; k++)
                    {
                        if (seedsFound.ContainsKey(k))
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
                var notMappedKeys = allSeeds.Select(x => x.Key).ToList();

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

                    var soilsFound = allSeeds.Where(x => x.Value.Soil >= data[1] && x.Value.Soil <= data[1] + data[2])
                        .Aggregate(new Dictionary<long, Seed>(), (acc, x) =>
                        {
                            acc.Add(x.Value.Soil, x.Value);
                            return acc;
                        });

                    if (soilsFound.Count == 0) continue;


                    for (long k = data[1]; k <= data[1] + data[2]; k++)
                    {
                        if (soilsFound.ContainsKey(k))
                        {
                            allSeeds[soilsFound[k].Id].Fertilazer = data[0];
                            notMappedKeys.Remove(soilsFound[k].Id);
                        }


                        data[0] += 1;
                    }
                }

                foreach (var s in notMappedKeys)
                {
                    allSeeds[s].Fertilazer = allSeeds[s].Soil;
                }

                continue;
            }

            if (line.StartsWith("fertilizer-to-water map:"))
            {
                var notMappedKeys = allSeeds.Select(x => x.Key).ToList();


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

                    var fertilizersFound = allSeeds.Where(x =>
                            x.Value.Fertilazer >= data[1] && x.Value.Fertilazer <= data[1] + data[2])
                        .Aggregate(new Dictionary<long, Seed>(), (acc, x) =>
                        {
                            acc.Add(x.Value.Fertilazer, x.Value);
                            return acc;
                        });


                    for (long k = data[1]; k < data[1] + data[2]; k++)
                    {
                        if (fertilizersFound.ContainsKey(k))
                        {
                            allSeeds[fertilizersFound[k].Id].Water = data[0];
                            notMappedKeys.Remove(fertilizersFound[k].Id);
                        }


                        data[0] += 1;
                    }
                }

                foreach (var s in notMappedKeys)
                {
                    allSeeds[s].Water = allSeeds[s].Fertilazer;
                }

                continue;
            }

            if (line.StartsWith("water-to-light map:"))
            {
                var notMappedKeys = allSeeds.Select(x => x.Key).ToList();

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

                    var waterFound = allSeeds.Where(x => x.Value.Water >= data[1] && x.Value.Water <= data[1] + data[2])
                        .Aggregate(new Dictionary<long, Seed>(), (acc, x) =>
                        {
                            acc.Add(x.Value.Water, x.Value);
                            return acc;
                        });

                    for (long k = data[1]; k < data[1] + data[2]; k++)
                    {
                        if (waterFound.ContainsKey(k))
                        {
                            allSeeds[waterFound[k].Id].Light = data[0];
                            notMappedKeys.Remove(waterFound[k].Id);
                        }


                        data[0] += 1;
                    }
                }

                foreach (var s in notMappedKeys)
                {
                    allSeeds[s].Light = allSeeds[s].Water;
                }

                continue;
            }

            if (line.StartsWith("light-to-temperature map:"))
            {
                var notMappedKeys = allSeeds.Select(x => x.Key).ToList();


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

                    var lightFound = allSeeds.Where(x => x.Value.Light >= data[1] && x.Value.Light <= data[1] + data[2])
                        .Aggregate(new Dictionary<long, Seed>(), (acc, x) =>
                        {
                            acc.Add(x.Value.Light, x.Value);
                            return acc;
                        });

                    for (long k = data[1]; k < data[1] + data[2]; k++)
                    {
                        if (lightFound.ContainsKey(k))
                        {
                            allSeeds[lightFound[k].Id].Temperature = data[0];
                            notMappedKeys.Remove(lightFound[k].Id);
                        }


                        data[0] += 1;
                    }
                }

                foreach (var s in notMappedKeys)
                {
                    allSeeds[s].Temperature = allSeeds[s].Light;
                }

                continue;
            }

            if (line.StartsWith("temperature-to-humidity map:"))
            {
                var notMappedKeys = allSeeds.Select(x => x.Key).ToList();

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

                    var temperatureFound = allSeeds.Where(x =>
                            x.Value.Temperature >= data[1] && x.Value.Temperature <= data[1] + data[2])
                        .Aggregate(new Dictionary<long, Seed>(), (acc, x) =>
                        {
                            acc.Add(x.Value.Temperature, x.Value);
                            return acc;
                        });

                    for (long k = data[1]; k < data[1] + data[2]; k++)
                    {
                        if (temperatureFound.ContainsKey(k))
                        {
                            allSeeds[temperatureFound[k].Id].Humidity = data[0];
                            notMappedKeys.Remove(temperatureFound[k].Id);
                        }


                        data[0] += 1;
                    }
                }

                foreach (var s in notMappedKeys)
                {
                    allSeeds[s].Humidity = allSeeds[s].Temperature;
                }

                continue;
            }

            if (line.StartsWith("humidity-to-location map:"))
            {
                var notMappedKeys = allSeeds.Select(x => x.Key).ToList();

                // Same as above
                for (var j = i + 1; j < input.Length; j++)
                {
                    var mapLine = input[j];
                    if (mapLine.Trim() == String.Empty)
                    {
                        i = j;
                        break;
                    }

                    // 0 => LOCATION IDs | 1 => HUMIDITY IDs | 2 => LENGTH
                    var data = mapLine.Split(" ").Select(long.Parse).ToList();

                    var humidityFound = allSeeds
                        .Where(x => x.Value.Humidity >= data[1] && x.Value.Humidity <= data[1] + data[2])
                        .Aggregate(new Dictionary<long, Seed>(), (acc, x) =>
                        {
                            acc.Add(x.Value.Humidity, x.Value);
                            return acc;
                        });

                    for (long k = data[1]; k < data[1] + data[2]; k++)
                    {
                        if (humidityFound.ContainsKey(k))
                        {
                            allSeeds[humidityFound[k].Id].Location = data[0];
                            notMappedKeys.Remove(humidityFound[k].Id);
                        }


                        data[0] += 1;
                    }
                }

                foreach (var s in notMappedKeys)
                {
                    allSeeds[s].Location = allSeeds[s].Humidity;
                }
            }
        }

        // foreach (var seed in allSeeds)
        // {
        //     Console.WriteLine(
        //         $"Seed: {seed.Value.Id} | Soil: {seed.Value.Soil} | Fertilizer: {seed.Value.Fertilazer} | Water: {seed.Value.Water} | Light: {seed.Value.Light} | Temperature: {seed.Value.Temperature} | Humidity: {seed.Value.Humidity} | Location: {seed.Value.Location}");
        // }

// Select Min Location Id from allSeeds
        var result = allSeeds.OrderBy(x => x.Value.Location).First();
        return result.Value.Location;
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