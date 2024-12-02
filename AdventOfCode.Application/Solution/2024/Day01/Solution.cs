using AdventOfCode.Application.Result;
using AdventOfCode.Application.Solution.Abstractions;

using static AdventOfCode.Application.Result.AdventResult<object>;

namespace AdventOfCode.Application.Solution._2024.Day01;

public class Solution : ISolution
{
    public AdventResult<object> PartOne()
    {
        var input = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}/Solution/2024/Day01/Input.txt").ReadToEnd();

        var column1 = input.Split('\n').Select(l => Int32.Parse(l.Split("   ")[0])).Order();
        var column2 = input.Split('\n').Select(l => Int32.Parse(l.Split("   ")[1])).Order();

        var answer = Enumerable.Zip(column1, column1)
                               .Select(p => Math.Abs(p.First - p.Second))
                               .Sum();

        return Success(answer);
    }

    public AdventResult<object> PartTwo()
    {
        return Failure(new AdventError(0002, "Part two not implemented"));
    }
}
