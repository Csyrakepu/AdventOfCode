
namespace AdventOfCode2023;
class Day7
{
    public static int Part1()
    {
        string[] lines = Source.GetSourceLines(7);

        var hands = lines.Select(line => new CardSet(line.Split(" ")[0], int.Parse(line.Split(" ")[1])));
        List<CardSet> sortedHands = hands.Order(comparer: new CardComparer(false)).ToList();

        return GetOutput(sortedHands);
    }

    public static int Part2()
    {
        string[] lines = Source.GetSourceLines(7);

        var hands = lines.Select(line => new CardSet(line.Split(" ")[0], int.Parse(line.Split(" ")[1])));
        List<CardSet> sortedHands = hands.Order(comparer: new CardComparer(true)).ToList();

        return GetOutput(sortedHands);
    }

    static int GetOutput(List<CardSet> sortedCardSets)
    {
        int output = 0;       
        for (int i = 0; i < sortedCardSets.Count; i++)
        {
            int multiplier = i + 1;
            output += sortedCardSets[i].bet * multiplier;
        }
        return output;
    }
}

class CardSet
{
    public enum Hand
    {
        FiveOfAKind = 7,
        FourOfAKind = 6,
        FullHouse = 5,
        ThreeOfAKind = 4,
        TwoPair = 3,
        OnePair = 2,
        HighCard = 1,
        Error = 0,
    }

    static readonly char[] possibleCards = "23456789TJQKA".ToCharArray();

    public string cards { get; set; }
    public int bet {  get; set; }
    public Hand hand { get; set; }


    public CardSet(string cards, int bet)
    {
        this.cards = cards;
        this.bet = bet;
        this.hand = GetHand();
    }

    public Hand GetHand()
    {
        var cardCounts = new Dictionary<char, int>();
        foreach (char possibleCard in possibleCards)
        {
            cardCounts[possibleCard] = cards.Count(ch => ch == possibleCard);
        }

        var sortedCounts = cardCounts.OrderBy(pair => -pair.Value).ToList();

        if (sortedCounts[0].Value == 5) return Hand.FiveOfAKind;
        if (sortedCounts[0].Value == 4) return Hand.FourOfAKind;
        if (sortedCounts[0].Value == 3 && sortedCounts[1].Value == 2) return Hand.FullHouse;
        if (sortedCounts[0].Value == 3 && sortedCounts[1].Value == 1) return Hand.ThreeOfAKind;
        if (sortedCounts[0].Value == 2 && sortedCounts[1].Value == 2) return Hand.TwoPair;
        if (sortedCounts[0].Value == 2 && sortedCounts[1].Value == 1) return Hand.OnePair;

        return Hand.Error;
    }

    public Hand GetHandWithJoker()
    {
        // talán ez hibás
        // vagy a sorter

        var cardCounts = new Dictionary<char, int>();
        foreach (char possibleCard in possibleCards)
        {
            cardCounts[possibleCard] = cards.Count(ch => ch == possibleCard);
        }

        var sortedCounts = cardCounts.OrderBy(pair => -pair.Value).ToList();
        sortedCounts.RemoveAll(pair => pair.Key == 'J');

        int jokerCount = (cards.Contains('J')) ? cardCounts.First(pair => pair.Key == 'J').Value : 0;

        if (sortedCounts[0].Value + jokerCount == 5) return Hand.FiveOfAKind;
        if (sortedCounts[0].Value + jokerCount == 4) return Hand.FourOfAKind;
        if (sortedCounts[0].Value + jokerCount == 3 && sortedCounts[1].Value == 2) return Hand.FullHouse;
        if (sortedCounts[0].Value + jokerCount == 3 && sortedCounts[1].Value == 1) return Hand.ThreeOfAKind;
        if (sortedCounts[0].Value + jokerCount == 2 && sortedCounts[1].Value == 2) return Hand.TwoPair;
        if (sortedCounts[0].Value + jokerCount == 2 && sortedCounts[1].Value == 1) return Hand.OnePair;

        return Hand.Error;
    }

    public override string ToString()
    {
        return $"{cards} {bet} {GetHandWithJoker()}";
    }
}

class CardComparer : IComparer<CardSet>
{
    public readonly bool includeJoker;
    public readonly string cardOrder;
    public CardComparer(bool includeJoker)
    {
        this.includeJoker = includeJoker;
        this.cardOrder = (includeJoker) ? "J23456789TQKA" : "23456789TJQKA";
    }

    public int Compare(CardSet? x, CardSet? y)
    {
        int valueComparison;
        if (includeJoker)
        {
            valueComparison = x.GetHandWithJoker().CompareTo(y.GetHandWithJoker());
        }
        else
        {
            valueComparison = x.GetHand().CompareTo(y.GetHand());
        }
        
        if (valueComparison != 0) return valueComparison;

        for (int i = 0; i < x.cards.Length; i++)
        {
            int charComparison = cardOrder.IndexOf(x.cards[i]).CompareTo(cardOrder.IndexOf(y.cards[i]));
            if (charComparison != 0) return charComparison;
        }
        return 0;
    }
}