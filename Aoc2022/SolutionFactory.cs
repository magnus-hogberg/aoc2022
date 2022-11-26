using Aoc2022.Solutions;

namespace Aoc2022.Pages;

public interface ISolutionFactory
{
    ISolution GetSolution(string day);
}

public class SolutionFactory : ISolutionFactory
{
    public ISolution GetSolution(string day)
    {
        switch (day)
        {
            case "1":
                return new SolutionDec1();
            default:
                return new DefaultSolution();
        }
    }
}