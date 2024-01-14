namespace dotnet_aoc.DaySeven;

public static class DaySeven
{
    public static long PartOne(string[] inputs)
    {
        var input = @"32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483".Split('\n');

        long result = 0;

        var cardsStrength = new Dictionary<string, int>();

        cardsStrength.Add("A", 14);
        cardsStrength.Add("K", 13);
        cardsStrength.Add("Q", 12);
        cardsStrength.Add("J", 11);
        cardsStrength.Add("T", 10);

        for (var i = 9; i > 1; i--)
        {
            cardsStrength.Add(i.ToString(), i);
        }


        var handsData = new List<HandsData>();


        foreach (var line in input)
        {
            var hand = line.Split(' ')[0].ToCharArray();
            var bid = int.Parse(line.Split(' ')[1]);


            var cardNumbers = new List<int>();

            var pairsDic = new Dictionary<string, int>();

            var handType = HandTypes.HighCard;


            foreach (var card in hand)
            {
                if (pairsDic.ContainsKey(card.ToString())) pairsDic[card.ToString()]++;
                else pairsDic.Add(card.ToString(), 1);

                cardNumbers.Add(cardsStrength[card.ToString()]);
            }

            var pairs = pairsDic.Count;


            if (pairs == 1) handType = HandTypes.FiveOfAKind;
            else if (pairs == 2)
            {
                if (pairsDic.ContainsValue(4)) handType = HandTypes.FourOfAKind;
                else handType = HandTypes.FullHouse;
            }
            else if (pairs == 3)
            {
                if (pairsDic.ContainsValue(3)) handType = HandTypes.ThreeOfAKind;
                else handType = HandTypes.TwoPairs;
            }
            else if (pairs == 4) handType = HandTypes.Pair;


            handsData.Add(new HandsData
            {
                HandType = handType,
                Bid = bid,
                CardNumbers = cardNumbers.ToArray()
            });
        }


        var orderData = handsData.OrderBy(x => x.HandType);


        foreach (var hand in orderData)
        {
            Console.WriteLine($"{hand.HandType} || {hand.Bid} || {string.Join(",", hand.CardNumbers)}");
        }

        for (var i = 0; i < orderData.Count(); i++)
        {
            result += orderData.ElementAt(i).Bid * (i + 1);
        }

        return result;
    }

    public static int PartTwo(string[] input)
    {
        return 0;
    }
}

enum HandTypes
{
    HighCard,
    Pair,
    TwoPairs,
    ThreeOfAKind,
    FullHouse,
    FourOfAKind,
    FiveOfAKind,
}

struct HandsData
{
    public HandTypes HandType { get; set; }
    public int Bid { get; set; }
    public int[] CardNumbers { get; set; }
}