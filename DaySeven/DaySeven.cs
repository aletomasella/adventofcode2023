namespace dotnet_aoc.DaySeven;

public static class DaySeven
{
    public static long PartOne(string[] input)
    {
//         var input = @"32T3K 765
// T55J5 684
// KK677 28
// KTJJT 220
// QQQJA 483".Split('\n');

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

            var concatCardNumbers =
                int.Parse(string.Join("", cardNumbers.Select(x => x < 10 ? $"0{x}" : x.ToString())));

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
                CardNumbers = concatCardNumbers
            });
        }


        var orderData = handsData.OrderBy(x => x.HandType).ThenBy(x => x.CardNumbers).ToArray();


        // foreach (var hand in orderData)
        // {
        //     Console.WriteLine($"{hand.HandType} || {hand.Bid} || {string.Join(",", hand.CardNumbers)}");
        // }

        for (var i = 0; i < orderData.Count(); i++)
        {
            result += orderData.ElementAt(i).Bid * (i + 1);
        }

        return result;
    }

    public static long PartTwo(string[] input)
    {
        long result = 0;

        var cardsStrength = new Dictionary<string, int>();

        cardsStrength.Add("A", 14);
        cardsStrength.Add("K", 13);
        cardsStrength.Add("Q", 12);
        cardsStrength.Add("T", 10);
        // Js are Jokers
        cardsStrength.Add("J", 1);

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

            var jokers = 0;

            foreach (var card in hand)
            {
                if (pairsDic.ContainsKey(card.ToString()) && card != 'J') pairsDic[card.ToString()]++;
                else if (card != 'J') pairsDic.Add(card.ToString(), 1);
                else jokers++;

                cardNumbers.Add(cardsStrength[card.ToString()]);
            }

            var concatCardNumbers =
                int.Parse(string.Join("", cardNumbers.Select(x => x < 10 ? $"0{x}" : x.ToString())));


            // var pairs = pairsDic.Count;
            //
            // switch (pairs)
            // {
            //     case 0:
            //         handType = HandTypes.FiveOfAKind;
            //         break;
            //     case 1:
            //         handType = HandTypes.FiveOfAKind;
            //         break;
            //     case 2:
            //         if (pairsDic.ContainsValue(4) && jokers == 1) handType = HandTypes.FiveOfAKind;
            //         else if (pairsDic.ContainsValue(4)) handType = HandTypes.FourOfAKind;
            //         else if (pairsDic.ContainsValue(3) && jokers == 1) handType = HandTypes.FourOfAKind;
            //         else if (pairsDic.ContainsValue(3)) handType = HandTypes.FullHouse;
            //         else if (jokers == 2) handType = HandTypes.FourOfAKind;
            //         else handType = HandTypes.FullHouse;
            //         break;
            //     case 3:
            //         if (pairsDic.ContainsValue(3) && jokers == 1) handType = HandTypes.FourOfAKind;
            //         else if (pairsDic.ContainsValue(3)) handType = HandTypes.ThreeOfAKind;
            //         else if (jokers == 1) handType = HandTypes.ThreeOfAKind;
            //         else if (jokers == 2) handType = HandTypes.ThreeOfAKind;
            //         else handType = HandTypes.TwoPairs;
            //         break;
            //     case 4:
            //         handType = HandTypes.Pair;
            //         break;
            //     default:
            //         handType = HandTypes.HighCard;
            //         break;
            // }

            var jokerCount = jokers;
            // logic to calculate strength of the hand
            if (pairsDic.Any(c => c.Value == (5 - jokerCount)))
            {
                // five of a kind
                handType = HandTypes.FiveOfAKind;
            }
            else if (jokerCount == 5)
            {
                handType = HandTypes.FiveOfAKind;
            }
            else if (pairsDic.Any(c => c.Value >= (4 - jokerCount)))
            {
                // four of a kind
                handType = HandTypes.FourOfAKind;
            }
            else if ((pairsDic.Any(c => c.Value == 3) && pairsDic.Any(c => c.Value == 2)) ||
                     (jokerCount == 1 && pairsDic.Count(c => c.Value == 2) == 2) ||
                     (jokerCount >= 2 && pairsDic.Any(c => c.Value == 2)))
                // 0 jokers => classic full house
                // 1 joker => 2 pairs
                // 2 jokers => 1 pair
            {
                // full house
                handType = HandTypes.FullHouse;
            }
            else if (pairsDic.Any(c => c.Value == (3 - jokerCount)))
            {
                // three of a kind
                handType = HandTypes.ThreeOfAKind;
            }
            else if (pairsDic.Count(c => c.Value == 2) == 2 ||
                     (jokerCount == 1 && pairsDic.Count(c => c.Value == 2) >= 1) ||
                     (jokerCount == 2))
            {
                // two pairs
                handType = HandTypes.TwoPairs;
            }
            else if (pairsDic.Any(c => c.Value == (2 - jokerCount)))
            {
                // one pair
                handType = HandTypes.Pair;
            }
            else
            {
                // high card
                handType = HandTypes.HighCard;
            }

            handsData.Add(new HandsData
            {
                HandType = handType,
                Bid = bid,
                CardNumbers = concatCardNumbers,
                Cards = hand
            });
        }


        var orderData = handsData.OrderBy(x => x.HandType).ThenBy(x => x.CardNumbers).ToArray();


        foreach (var hand in orderData)
        {
            Console.WriteLine(
                $"{hand.HandType} || {string.Join("", hand.Cards)} || {hand.Bid} || {string.Join(",", hand.CardNumbers)}");
        }


        for (var i = 0; i < orderData.Count(); i++)
        {
            result += orderData.ElementAt(i).Bid * (i + 1);
        }

        return result;
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
    public int CardNumbers { get; set; }

    public char[] Cards { get; set; }
}