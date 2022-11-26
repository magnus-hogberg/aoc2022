namespace Aoc2022;

public interface ISolution 
{
    public string Name {get;}
    public string Solution1();
    public string Solution2();
}

class DefaultSolution : ISolution
{
    public string Name => "This solution does not exist yet!";
    public string Solution1()
    {
        throw new NotImplementedException();
    }

    public string Solution2()
    {
        throw new NotImplementedException();
    }
}