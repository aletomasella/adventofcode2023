namespace dotnet_aoc.DayFour;

public class DayFour
{
    public static int PartOne(string[] input)
    {
        // INPUT : Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53


        // CARD ID => [WINNING NUMBERS]
        var matchNumbers = new Dictionary<int, int>();

        foreach (var line in input)
        {
            var cardId = int.Parse(line.Split(':')[0].Replace("Card ", "").Trim());

            var winningNumbers = line.Split(':')[1].Split('|')[0].Split(' ').Where(x => x.Trim() != String.Empty)
                .Select(int.Parse)
                .ToList();

            var numbersWeHave = line.Split(':')[1].Split('|')[1].Split(' ').Where(x => x.Trim() != String.Empty)
                .Select(int.Parse).ToList();

            var matches = numbersWeHave.Intersect(winningNumbers).ToList();

            var points = Math.Pow(2, matches.Count - 1);

            matchNumbers.Add(cardId, (int)points);
        }

        var result = matchNumbers.Sum(x => x.Value);

        return result;
    }

    public static int PartTwo(string[] input)
    {
        return 0;
    }
}