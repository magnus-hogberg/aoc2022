namespace Aoc2022.Solutions;

public class SolutionDec2 : ISolution
{
    public string Name => "Dec 2";

    private enum Hand
    {
        Paper,
        Scissors,
        Rock
    }

    private enum Outcome
    {
        Win,
        Lose,
        Draw
    }

    public string Solution1()
    {
        var totalScore = 0;
        foreach (var game in DataList)
        {
            var myHand = ToHand(game.Last());
            var theirHand = ToHand(game.First());
            totalScore += GetScore(myHand, theirHand);
        }

        return totalScore.ToString();
    }

    private int GetScore(Hand a, Hand b)
    {
        switch (a, b)
        {
            case (Hand.Paper, Hand.Rock):
                return 8;
            case (Hand.Paper, Hand.Scissors):
                return 2;
            case (Hand.Paper, Hand.Paper):
                return 5;
            case (Hand.Rock, Hand.Scissors):
                return 7;
            case (Hand.Rock, Hand.Paper):
                return 1;
            case (Hand.Rock, Hand.Rock):
                return 4;
            case (Hand.Scissors, Hand.Paper):
                return 9;
            case (Hand.Scissors, Hand.Rock):
                return 3;
            case (Hand.Scissors, Hand.Scissors):
                return 6;
            default:
                throw new NotImplementedException();
        }
    }

    public string Solution2()
    {
        var totalScore = 0;
        foreach (var game in DataList)
        {
            var theirHand = ToHand(game.First());
            var myHand = ToHand(theirHand, ToOutcome(game.Last()));
            totalScore += GetScore(myHand, theirHand);
        }

        return totalScore.ToString();
    }

    private IEnumerable<IEnumerable<string>> DataList => Data.Split('\n').Select(s => s.Split(' '));
    private IEnumerable<IEnumerable<string>> TestDataList => TestData.Split('\n').Select(s => s.Split(' '));

    private Outcome ToOutcome(string s)
    {
        switch (s)
        {
            case "X":
                return Outcome.Lose;
            case "Y":
                return Outcome.Draw;
            case "Z":
                return Outcome.Win;
            default:
                throw new NotImplementedException();
        }
    }

    private Hand ToHand(Hand opponent, Outcome outcome)
    {
        if (outcome == Outcome.Draw)
            return opponent;
        switch (opponent, outcome)
        {
            case (Hand.Paper, Outcome.Lose):
                return Hand.Rock;
            case (Hand.Paper, Outcome.Win):
                return Hand.Scissors;
            case (Hand.Rock, Outcome.Lose):
                return Hand.Scissors;
            case (Hand.Rock, Outcome.Win):
                return Hand.Paper;
            case (Hand.Scissors, Outcome.Lose):
                return Hand.Paper;
            case (Hand.Scissors, Outcome.Win):
                return Hand.Rock;
            default:
                throw new NotImplementedException();
        }
    }

    private Hand ToHand(string s)
    {
        switch (s)
        {
            case "A":
            case "X":
                return Hand.Rock;
            case "B":
            case "Y":
                return Hand.Paper;
            case "C":
            case "Z":
                return Hand.Scissors;
            default:
                throw new NotImplementedException();
        }
    }

    private string TestData = """
    A Y
    B X
    C Z
    """;

    private string Data = """
    C Y
    C Z
    B Z
    A Z
    A Z
    A Y
    A Z
    C Y
    C Z
    A Y
    A Y
    B X
    A Y
    C Z
    C Z
    B X
    C Z
    A Z
    B Y
    C Z
    A Y
    C X
    B Y
    A Z
    B Y
    C Z
    B Z
    B Y
    C Z
    A Z
    A Z
    B Z
    C Z
    A X
    B X
    C Y
    C Z
    C Z
    C Z
    A Y
    C Z
    C Z
    C Z
    C X
    A Z
    A Z
    C Y
    A Z
    C Z
    C Z
    C Z
    A Z
    B Y
    C Z
    A Z
    B Z
    A Z
    A Y
    B X
    B X
    C Z
    C X
    C Z
    C Z
    A Z
    B Z
    B X
    B X
    B Y
    C X
    C Y
    A Y
    C Z
    A Y
    C Z
    A X
    B X
    B X
    C X
    B X
    B X
    A Y
    B Y
    C Y
    A Z
    C Y
    B Y
    B X
    B X
    B Z
    B X
    B Z
    A Z
    B Y
    C Z
    B Z
    B Z
    B Y
    A Y
    C Z
    A Z
    C Y
    C Z
    B Z
    C Z
    C Z
    B Y
    A Z
    C Z
    C Z
    A Z
    A Z
    B X
    C Y
    A Y
    C Z
    B Y
    C Z
    A Y
    C X
    C X
    B Y
    C Z
    C X
    C Z
    B Y
    A Y
    B Z
    C Z
    B Y
    C Y
    C Z
    C Z
    B Z
    C Z
    A Z
    A Y
    C Z
    C Z
    B Y
    A Z
    C Z
    C Z
    C Y
    B Y
    C Z
    C Z
    C Z
    C Z
    A X
    B Y
    C Z
    B Y
    C Z
    B Y
    C X
    C Y
    A X
    C Z
    B X
    B X
    A Z
    A Z
    A Z
    B Y
    C Z
    B Z
    A Z
    B Y
    C Y
    C Z
    C Z
    C Z
    C Y
    C Z
    B Y
    C Z
    C Z
    B Z
    A Y
    B Z
    C Z
    C Y
    A Z
    C X
    B Z
    C Y
    B Y
    C Z
    C Z
    A Z
    C Y
    C Y
    C Y
    B Y
    C Z
    C X
    B Y
    C Z
    C Y
    B Z
    A Y
    C Z
    A Y
    B Z
    A Y
    A Y
    B Z
    A Z
    C Z
    C Z
    B X
    C Z
    C Z
    B X
    B Y
    C Z
    C X
    A X
    C Z
    C Z
    C Z
    B X
    B X
    A Z
    C Z
    C X
    A Z
    C Z
    C Z
    A Z
    B Z
    C Z
    B Y
    C Z
    A Y
    B Z
    C Z
    C Z
    C Z
    C X
    A X
    A Y
    B Y
    C Z
    B Y
    C X
    A Y
    C Z
    C Z
    B Y
    B Z
    C Z
    B Y
    B Y
    B Y
    A Y
    C Z
    B Z
    A X
    B Y
    C Z
    C Z
    C X
    A Y
    C Z
    A X
    B Y
    A X
    A Z
    B X
    B X
    C Z
    C Z
    A X
    C Z
    A Y
    B Y
    B Z
    C X
    C Y
    B X
    C Z
    C Y
    B Y
    C Z
    C X
    B Z
    C Z
    C Z
    C X
    C Y
    C Z
    A Y
    C Z
    C Z
    C Z
    C Z
    C Z
    C Y
    B Y
    C Z
    A X
    A Z
    C Y
    B Z
    B X
    A Z
    C Z
    C Y
    C Z
    C X
    A Y
    C Z
    A Z
    B Y
    B Z
    C Z
    B Z
    A Y
    C Z
    B Y
    C Z
    C Y
    C Z
    C X
    A Y
    A Y
    C Y
    C Z
    C Z
    B Y
    A Z
    C Z
    C Y
    A Y
    A Z
    A Z
    C X
    C Z
    B X
    C Y
    C Z
    C Z
    B Y
    C Z
    B X
    C Z
    B Z
    B Y
    C X
    C X
    A X
    B Y
    A Z
    C X
    B X
    A Z
    C Z
    C Z
    A X
    A Y
    B X
    C Z
    A X
    C Z
    B Y
    C Z
    A Y
    B Y
    C Z
    B Z
    B Y
    A Z
    C Z
    A X
    B Z
    C Y
    B Z
    B Y
    A Z
    A Y
    A Z
    A X
    C X
    A X
    C Y
    C Z
    A Y
    C Y
    B X
    A X
    A Y
    C Y
    B Y
    C Z
    C Z
    B Z
    C Z
    C Z
    C Z
    C Z
    C Z
    C Z
    C Z
    B Y
    C Z
    A Y
    B Y
    C Y
    C X
    C Z
    B Z
    B Y
    C Y
    C Z
    A Z
    C Y
    B Z
    C Z
    A Z
    C X
    B Y
    B Y
    B Y
    C Z
    B Y
    A Y
    C Z
    C Z
    A Z
    A Z
    C Z
    B Z
    B Y
    C Z
    B Y
    B Z
    C Z
    A X
    A X
    C X
    C Y
    A Y
    C Z
    A Y
    A Z
    C Z
    C Z
    C Z
    B Y
    A Z
    B Z
    C X
    B X
    C X
    B Y
    C Z
    A Z
    C Z
    A X
    B Z
    B Z
    B Y
    A Y
    C Z
    B X
    C Z
    B Z
    C X
    A X
    C Z
    C Z
    B Z
    B Y
    C Z
    C Z
    A Z
    C Y
    C Z
    B Y
    A Y
    B Y
    A Y
    C Z
    C Y
    B Z
    A Y
    C Z
    B X
    B X
    B X
    C Y
    C Z
    A Y
    C Z
    C Z
    C Z
    A Y
    C Z
    B X
    A Z
    C Z
    C Z
    A Y
    C Z
    C Z
    B X
    C Z
    B Y
    A Z
    C X
    C Y
    C Y
    C Z
    C Y
    A Y
    B Z
    C Z
    C Z
    C Z
    B Y
    C Z
    C Z
    A Y
    A X
    A Y
    C Y
    C Z
    C Z
    A X
    B Z
    C Z
    C Z
    B Z
    B Y
    C Z
    A X
    C X
    A Z
    B Z
    C Z
    A X
    C X
    C Z
    B Y
    A X
    A X
    C Z
    C Z
    B X
    C Z
    B Z
    B Y
    A X
    C Y
    C Z
    C X
    A Y
    B Y
    C Z
    C Z
    C Z
    C Z
    B Z
    A Y
    C Z
    C Z
    B Z
    C Y
    B Z
    B X
    B Y
    A Z
    C Z
    A Z
    B Y
    C Y
    C Z
    C Z
    C Z
    B Z
    C Z
    C X
    C Z
    B X
    C Y
    B Y
    C Z
    C Z
    C Z
    C Z
    B Y
    B Y
    C Z
    B Y
    C X
    B Z
    A X
    C X
    C Z
    B X
    C Z
    C X
    C Z
    A X
    A Z
    B X
    C Z
    C Z
    B Y
    C Z
    A Y
    C Z
    C Z
    C Y
    C Z
    A Z
    A X
    C X
    B Y
    A Y
    B Y
    A X
    C Z
    B Y
    B Y
    C Z
    C Z
    B Y
    B X
    A Y
    C Z
    B Y
    C Y
    C Z
    C Z
    C X
    B Y
    A Z
    C Z
    A Z
    A X
    C X
    A Z
    C Z
    C Z
    A X
    B Z
    C Z
    B Y
    A Z
    A Y
    A X
    A Y
    A X
    C Z
    A X
    B Y
    A Y
    B Z
    C Y
    C Z
    B Z
    C X
    A Y
    A Y
    C Z
    C Y
    C Z
    B Y
    B Y
    B Y
    B X
    C Z
    C X
    B Y
    C Z
    C Z
    B Y
    C Z
    C Z
    B Y
    C Z
    C Y
    C Z
    C Y
    C Z
    C Y
    A Y
    A Y
    C Y
    C Y
    C Y
    C Y
    C Z
    C X
    B Z
    B Z
    C X
    C Z
    B Y
    B Y
    A Z
    C Y
    C Z
    C Z
    C X
    C Z
    C Z
    A Z
    B Y
    C Z
    A Y
    C Z
    C Z
    C Z
    A Z
    C X
    C Y
    B Y
    A Z
    B Z
    C Z
    B Y
    C Z
    B Z
    C X
    A X
    C Y
    A Y
    B Z
    B Y
    A X
    C Z
    B Z
    C Z
    C Z
    C X
    B Z
    C X
    A Z
    B Z
    C Z
    C Z
    C Z
    B Y
    A X
    C Z
    C Y
    C Y
    C Z
    A Z
    C Z
    C Z
    A X
    C Y
    B Y
    A Y
    A Z
    A Z
    B Z
    C Z
    A Z
    B Y
    B Y
    A Y
    A Z
    A Z
    C Z
    C Z
    C Z
    A X
    C Z
    B Z
    B X
    C Y
    A Z
    B Y
    C Z
    B Y
    A X
    C Z
    A Z
    C Z
    B Z
    C Y
    C Z
    B Y
    A Z
    B Z
    A Y
    B X
    C Z
    B Y
    C Z
    C Z
    C X
    C Y
    C Z
    B X
    C X
    A Y
    A Y
    C Z
    C Y
    B Y
    C Y
    C Y
    C Z
    A Y
    A Z
    B Y
    C Z
    C Z
    A X
    C Z
    C Y
    C Z
    B X
    C Y
    A Z
    A Y
    A Z
    C X
    C Z
    C Z
    C Z
    B Z
    C Y
    B Z
    C Z
    B Y
    C Z
    B Y
    A Y
    B X
    C Z
    A Y
    C Z
    A Y
    A Z
    A Z
    B Z
    A Y
    C Z
    A X
    B Y
    C Z
    B Z
    C Z
    A Y
    A Y
    B Z
    B X
    B X
    C Y
    C Z
    C Z
    C Y
    A X
    B Z
    C X
    B Y
    C X
    B X
    C X
    C X
    C Z
    A Y
    C Y
    C Z
    B Z
    A Z
    A Z
    C Z
    A Z
    C Z
    A Z
    A X
    B Y
    A X
    A Y
    C X
    B Y
    C Z
    A X
    B X
    C Z
    C Z
    C X
    B X
    A Z
    B X
    C Z
    B Y
    C Z
    C X
    C Z
    C X
    C Z
    B Z
    B Y
    C Z
    B X
    C X
    C Z
    C Y
    A Z
    B Z
    A X
    B X
    B X
    C Z
    B Z
    C X
    A Y
    C Z
    C Z
    B Y
    C X
    C Z
    A X
    B Y
    C Z
    C Z
    C Z
    C Z
    C Z
    A X
    A Z
    C X
    A Z
    C Z
    A Z
    C Z
    B Y
    B Z
    A X
    C X
    C Z
    B Z
    A Z
    C Z
    C Y
    C Z
    C Z
    C X
    A Y
    B Y
    C Z
    A Y
    C Z
    B Z
    C X
    B Z
    B Z
    B X
    B Z
    C Y
    C Z
    C Y
    B Y
    C Y
    C Z
    C X
    C X
    A Z
    B Y
    C Z
    A Y
    B X
    C Y
    A Y
    A Z
    B Y
    B Y
    A Y
    B Y
    B Z
    A X
    C Z
    B Y
    A X
    C Z
    C Z
    C X
    B Y
    A Z
    A X
    B Y
    A Z
    C Z
    B Z
    B Z
    B Y
    B Y
    A Z
    A Z
    A Y
    C Z
    C Z
    A Z
    C Z
    C Z
    C Z
    A X
    C Z
    A Y
    C Y
    A Z
    C Z
    B Y
    C X
    B Y
    C Z
    C Z
    C Z
    A Z
    B Z
    B X
    C Z
    C Z
    A Y
    B Z
    B X
    C Z
    C Y
    A Y
    C Y
    C Y
    C Z
    C Y
    C X
    C Y
    B Z
    B Y
    C Z
    A Z
    A Y
    C Z
    C Z
    B Y
    B Y
    A Z
    A Z
    A X
    C Z
    C Z
    A Y
    B Y
    C X
    C Z
    C Z
    A Z
    C Z
    B X
    B Y
    A Y
    C Z
    A X
    A Y
    C Z
    B X
    C X
    B Z
    C Y
    C X
    B Y
    B Y
    C Z
    C Z
    C X
    C Z
    A Y
    A Z
    C Y
    C Z
    A Z
    C Z
    C Y
    A X
    C X
    C Z
    B X
    C Z
    B X
    C Z
    C Z
    C Z
    B X
    B Y
    B Y
    B Y
    C X
    B Y
    C Z
    C Y
    C Z
    C Z
    B X
    C Y
    B Z
    C Z
    C Y
    C X
    C Z
    A X
    A Z
    C Z
    C Y
    C X
    C Z
    B Y
    C X
    C Y
    C Z
    C X
    A Z
    B Y
    B X
    C X
    C Y
    B Z
    C Z
    C Y
    B Z
    C X
    A Z
    A Y
    C Z
    C Z
    C X
    B Y
    C Y
    C Z
    A Z
    B Z
    B Y
    B Y
    B Z
    C Z
    A X
    B Y
    A Z
    A Y
    C Z
    C Z
    B Y
    C Y
    C Z
    B Z
    A Z
    B Z
    C Z
    C Z
    B Y
    B X
    C Z
    C Y
    C Z
    A Y
    C Z
    A X
    C X
    B Y
    B X
    C X
    C Z
    C X
    B Z
    C Z
    A Z
    B Z
    C Z
    A X
    C Z
    C Z
    A Y
    B Y
    B Z
    B X
    B Z
    C X
    B Y
    C Z
    C Z
    C Z
    A Z
    C Z
    C X
    C X
    B Y
    C X
    C X
    C Z
    C Z
    A Z
    C Y
    C Z
    C Z
    B Z
    C Z
    A Y
    B Y
    C Z
    C Z
    B Y
    B Y
    C X
    C Z
    B X
    A Y
    B Z
    A Y
    A Y
    A Y
    C Y
    C Y
    C Z
    B X
    B Z
    C Z
    C X
    C X
    B Z
    A Z
    A X
    B Y
    C Z
    B Z
    A Z
    B X
    C Z
    A Y
    C Z
    A Z
    A Z
    C Z
    C X
    C Z
    C Y
    A X
    B Y
    C Z
    C Z
    C Z
    C Z
    C Z
    A Y
    C X
    C Z
    A Y
    B X
    C Z
    A Y
    C Z
    C Z
    C Y
    B Z
    B X
    C Z
    A X
    B Y
    C Z
    C Z
    A X
    A Y
    C Z
    C Y
    B Y
    C Z
    C Z
    A Y
    A Y
    A Y
    A Y
    C Z
    A X
    A Z
    B Y
    B Z
    A Z
    C Y
    C Z
    C Z
    C Z
    A Z
    C Z
    A Z
    C Z
    C Z
    A Z
    C Z
    C Z
    A Z
    B X
    C Z
    A Y
    B Y
    C Z
    A X
    C Z
    A Y
    C Z
    C Z
    C Y
    C Z
    A X
    B Y
    C Z
    A Z
    C Z
    A Z
    A Z
    B Y
    C X
    B Y
    C X
    C X
    C Z
    A Y
    B Z
    A Y
    C Z
    C Z
    B Z
    A Y
    C Z
    B Y
    C Z
    A X
    C Z
    C Z
    C Z
    B Z
    A X
    B Y
    C Z
    A X
    C Z
    C X
    B Y
    C Z
    A Y
    C Y
    B Y
    A Y
    C Z
    A X
    B Y
    A Y
    A Z
    C Z
    C Z
    C X
    A Z
    C Z
    C Z
    B Y
    B X
    A Z
    C Z
    B X
    C Z
    C Y
    C Z
    C Z
    C Z
    C Y
    A Y
    C Z
    C Y
    C Z
    C Z
    B Y
    B Y
    B X
    C Y
    B Z
    C Z
    B Y
    C Z
    C Z
    C Z
    A Z
    A Y
    C Y
    C Z
    C Z
    A Z
    C Z
    C Z
    C Z
    B Y
    B X
    B Y
    A Y
    C Z
    B Z
    C Z
    B Y
    B Z
    A Y
    C Z
    C Z
    C Y
    A Y
    C Z
    C Z
    B Y
    A Z
    A Y
    C Z
    C Z
    B Y
    C Z
    B Y
    B Z
    C X
    C Y
    C Z
    A Y
    C Z
    A Z
    A X
    B X
    C Z
    C Y
    C Z
    C X
    B X
    B Y
    B Y
    C Z
    C Z
    C Z
    A X
    B Z
    C Z
    A Z
    A Z
    C Z
    B Y
    B X
    B Y
    C Z
    B Z
    C Z
    B X
    B Z
    C Z
    B X
    A X
    C Z
    C X
    B Z
    C Y
    C X
    C Z
    C X
    A X
    A X
    C Z
    C Z
    C Z
    B X
    B X
    C Z
    C Z
    C X
    C X
    C Z
    A Y
    B Y
    B Y
    B Y
    C Z
    C Y
    C Z
    C Z
    C Z
    B Y
    C Y
    C Z
    B X
    C Z
    A X
    C Y
    A Y
    C X
    A Y
    A Z
    C Z
    B Y
    B Y
    A Z
    C Y
    B Z
    B Z
    A X
    B Y
    C Z
    B X
    A Z
    A Z
    C Z
    B Z
    A Z
    C X
    B Z
    C Z
    C Z
    C Z
    C Z
    B X
    B Y
    C Z
    C Z
    C X
    C Y
    A Z
    B X
    B Y
    B Z
    C Z
    B Z
    C Z
    C Z
    C Z
    C Z
    A Y
    C X
    C Z
    A Y
    C Z
    C Z
    B Z
    C Z
    A Z
    C Z
    A Y
    C X
    C Z
    A X
    C X
    C Z
    C Z
    B Y
    C Z
    A Z
    C X
    C Z
    B Y
    A Y
    B Y
    C Z
    B X
    A X
    C Z
    B Y
    C Z
    B Y
    A Z
    A Z
    C Z
    A Z
    B Y
    C Z
    C Y
    B X
    C Z
    A Z
    B Z
    C Z
    C Y
    C Z
    B Z
    A X
    A X
    A Z
    C Z
    C Z
    C Y
    C X
    C X
    A X
    C X
    B X
    C X
    A Y
    C Y
    C Z
    C Z
    C Z
    C Z
    C X
    A Y
    C Y
    A Y
    B X
    C Y
    C Z
    A X
    A Z
    C Z
    C Z
    B Y
    C Z
    B Z
    C Z
    C Z
    A Y
    A Y
    C Z
    C Z
    A Z
    C Z
    C Z
    B X
    C Y
    C Z
    C Z
    C Z
    C Z
    A X
    B Y
    B X
    B Z
    C Z
    A Z
    A Z
    B Z
    A Z
    B X
    C Z
    B Z
    C Z
    A Z
    C Z
    C Z
    A Y
    B Y
    C Y
    B X
    A Z
    C X
    C Z
    C X
    B Y
    B Z
    C Z
    C Z
    C Z
    C Y
    C Z
    A X
    A X
    A Y
    C X
    C X
    A Y
    B Y
    C X
    C Z
    C Z
    B X
    B Z
    B X
    C X
    B X
    A Y
    C Z
    A Z
    C Z
    C Z
    C Z
    C Z
    C X
    A Z
    B Y
    C Z
    C X
    A Y
    A Y
    C Z
    C Z
    B Z
    B X
    C Z
    A Z
    B Y
    C Z
    C Z
    B Y
    A Y
    C Z
    B Z
    B Z
    A Z
    C X
    C Z
    B Z
    C Z
    C Z
    B Y
    C X
    B Y
    A Z
    C Z
    A X
    C Z
    B Y
    C Z
    A Z
    B Z
    C Z
    A Z
    A Y
    C Y
    B X
    C Z
    A Y
    C Y
    A X
    A Z
    A Y
    C X
    C Z
    C Z
    B Z
    A Z
    C Z
    C Z
    C Y
    C X
    C Y
    B Y
    C Z
    B Y
    C Y
    C Y
    C Y
    A X
    C Z
    C Z
    B X
    B Y
    C Z
    A Y
    C Z
    A Y
    B Z
    C Z
    C Z
    C Z
    A Y
    A X
    B Z
    B Y
    A Y
    A Y
    B Y
    B Z
    C X
    A Y
    B Y
    C X
    C Z
    C Z
    B Y
    C Z
    C X
    C Z
    C X
    C Z
    A Y
    A Y
    B Y
    C Z
    A Z
    C Y
    C Z
    A X
    C Y
    C Y
    C Y
    A Z
    C X
    C Z
    C Z
    A Z
    C Z
    B Y
    C Y
    C Z
    C Z
    C Z
    B Z
    C X
    C Z
    C Z
    C X
    C Z
    C Z
    C X
    C Z
    C X
    B Z
    B X
    A X
    C Z
    A Y
    C Z
    B X
    C Y
    A X
    C X
    B Z
    C Z
    A Y
    A X
    C X
    B Z
    B Z
    C X
    A Y
    C Y
    A Y
    C Z
    C Y
    A X
    C Z
    A Y
    A Z
    C Z
    B Y
    C X
    A Y
    A Y
    C Y
    B Y
    A Z
    B Y
    C X
    A Y
    B Z
    B Z
    C Z
    C Y
    C Z
    B Y
    C X
    C Z
    C Z
    A Y
    C Z
    C X
    A Y
    C Z
    C Z
    B X
    C Z
    A X
    C Z
    A Y
    C Y
    A Y
    B X
    C Y
    C Y
    A Y
    C Z
    A Z
    C Z
    C Y
    C Z
    A Z
    A Z
    C Z
    C Z
    C Z
    C Z
    C Z
    A Y
    A Z
    B Y
    C Z
    A Y
    C Y
    C Z
    A Y
    C X
    C Z
    A Z
    C Z
    C Y
    C X
    C Z
    C Y
    A X
    B Y
    C Z
    A Y
    A Z
    C X
    C X
    C Z
    A Z
    C Z
    C Z
    C Z
    C Z
    A X
    C Z
    C Z
    C X
    C Z
    A Y
    C Z
    C Z
    B X
    B Y
    C Y
    B Z
    C Y
    C Z
    B Y
    A Y
    A Y
    B Y
    A Z
    B Z
    B Y
    A X
    C Z
    B X
    A Y
    C X
    C Z
    C X
    C Z
    C Z
    C X
    A Z
    B Y
    A X
    C Z
    C Z
    B Z
    C X
    C X
    B Z
    A Y
    A Y
    A Y
    A Z
    C Y
    C Z
    A X
    B Y
    C Z
    B Y
    B Y
    C Y
    C Z
    C Y
    B Y
    C Z
    B Z
    C X
    C X
    A X
    C Z
    C Z
    B Z
    A Y
    A Z
    B X
    B Z
    B Y
    C Z
    A Z
    C X
    A Z
    B Y
    C Z
    B Y
    A Y
    C Z
    A Y
    B Z
    C Z
    A Z
    B Z
    B Y
    B Y
    A X
    B Y
    B Y
    C Z
    B Y
    C Z
    B Z
    A Z
    A Y
    C Z
    B Y
    C Z
    C Z
    C X
    C X
    C Y
    B Y
    C Y
    A Z
    C Z
    A Z
    C Z
    B Z
    C Y
    C Z
    A X
    B X
    A Z
    A Y
    A Y
    C Z
    C Z
    C Z
    C Y
    C Z
    C Z
    A Z
    A X
    B X
    A Z
    C Y
    C Z
    B Y
    A Y
    A Y
    B X
    B X
    C Z
    C Z
    C Z
    C X
    C Z
    C Y
    C Z
    A Y
    C Z
    C Z
    C Y
    A Z
    B Y
    A Y
    B Y
    B Y
    A Y
    A Y
    B Z
    C Z
    C X
    B Y
    C Z
    C Z
    C X
    A Z
    B Y
    A Z
    C Z
    C Z
    B Y
    C X
    C Z
    C Y
    A Y
    C Z
    A Y
    B Y
    A Y
    C X
    C Y
    C Y
    B Y
    B Z
    A Z
    C Z
    C Y
    B Z
    B Y
    A Y
    A Z
    A Y
    A Y
    B X
    C Z
    A X
    B Y
    B Y
    C Z
    B Y
    B Y
    B Z
    C Z
    A Y
    C X
    A X
    A Y
    C X
    A Y
    A Z
    C Z
    B Y
    B Y
    B Y
    C Y
    A Y
    B Z
    C Z
    C Z
    B Z
    C Z
    B X
    C Y
    B Y
    A Z
    C X
    A Z
    C Z
    B X
    C Z
    C Z
    B Z
    C Z
    A Z
    A Z
    B Y
    C Z
    A Z
    C Y
    B Y
    B Z
    C Z
    C X
    C Z
    A Z
    C Z
    C Y
    C X
    A Y
    B Y
    B X
    C X
    C Z
    A Z
    C X
    B Z
    C Z
    A Y
    C Y
    C Z
    A Z
    C Z
    A Z
    C Y
    C X
    C Y
    B Z
    B Y
    A Z
    A Y
    B X
    A Z
    C X
    C Y
    C X
    C Z
    C X
    A X
    C Z
    B Y
    C Z
    A Y
    B Z
    C X
    B Y
    C Z
    A Z
    C Z
    C Z
    C Y
    A Y
    A Z
    A Y
    C X
    B Z
    A Z
    C Z
    C Z
    C Z
    A X
    C Z
    A Z
    A Y
    C X
    B X
    C Z
    C Z
    A X
    A Y
    C Z
    C X
    C Z
    A Z
    C Y
    C Z
    B Z
    C Y
    C X
    A Y
    A X
    A Z
    C Z
    C Z
    C Z
    C Z
    A Y
    C Z
    A Z
    A Y
    C Z
    B Z
    B Y
    C X
    C Z
    C X
    C Z
    B X
    A Y
    C Z
    B Z
    A Z
    A Z
    B Z
    B Z
    C Z
    C Z
    B Y
    C Z
    A Y
    C X
    A X
    A X
    C X
    C X
    B Y
    B X
    A Y
    C Z
    B X
    B Y
    A Z
    B Z
    A Z
    A Z
    C X
    C Z
    A X
    A Y
    C X
    C Y
    C Y
    C X
    A Z
    C Z
    C X
    C X
    A Y
    A X
    C Z
    C Z
    B Y
    B Z
    C X
    C X
    C Z
    B Z
    B Z
    B Z
    B Z
    B Y
    B X
    C Z
    C Z
    C Z
    C X
    C Z
    C Z
    B Y
    C Z
    C X
    B Y
    C Z
    C Y
    B Z
    C Y
    C Z
    C Z
    C Z
    C Z
    C Z
    C Z
    C Z
    A X
    A Y
    C Y
    C Z
    A Y
    B X
    C Z
    B Y
    C Y
    C Z
    C Z
    C Z
    C Y
    C Z
    A Z
    B Y
    A Z
    C Z
    B Z
    C X
    C X
    A Z
    C Z
    C X
    C Z
    B Z
    C Z
    C Y
    B X
    C Z
    A Z
    C X
    B Y
    B Y
    C Z
    C Z
    C Z
    B Y
    C Z
    B Y
    A Y
    B Z
    B Z
    B Y
    C Z
    B Z
    A X
    C Z
    C Z
    C Z
    B Y
    B Y
    C Z
    C Y
    C Z
    B Y
    C Z
    B X
    B Z
    C X
    B Y
    C Y
    B Y
    C Z
    A Y
    B Z
    C X
    B Y
    A Z
    C Z
    C X
    A Z
    B Z
    A Y
    C Z
    C X
    B Y
    C Z
    C Z
    B Y
    B Z
    C X
    C X
    C Z
    C Z
    C X
    B Z
    A Y
    C Z
    C X
    A Z
    C Z
    C Z
    C Z
    C Y
    B Z
    A X
    B Z
    B Z
    C Z
    C Z
    B Z
    C Z
    B Z
    A X
    B Z
    B Y
    B Z
    B Z
    B Y
    C X
    A Y
    B Y
    B X
    B X
    A X
    C Z
    C Y
    C Y
    C Y
    C Y
    B Y
    A X
    C Y
    A X
    C Z
    B Z
    C Z
    C Y
    B Y
    A Z
    C Y
    A Z
    B Y
    B X
    C Z
    A X
    A Z
    C Z
    C Z
    A X
    C Z
    C X
    A Z
    C Y
    B Z
    C Y
    B Z
    A Y
    A Z
    C Z
    A Y
    C Z
    C Z
    A X
    C Z
    C Z
    C Z
    B Y
    C X
    C Y
    C Z
    B X
    A Z
    C Z
    C X
    B Y
    A Y
    B Y
    C Z
    C Z
    C Z
    A Y
    A X
    C Z
    C Z
    C Z
    C Z
    B Y
    A Z
    C Z
    A X
    A Y
    B Z
    """;
}