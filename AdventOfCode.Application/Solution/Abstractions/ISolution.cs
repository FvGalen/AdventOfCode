using AdventOfCode.Application.Result;

namespace AdventOfCode.Application.Solution.Abstractions;

public interface ISolution
{
    AdventResult<object> PartOne();
    AdventResult<object> PartTwo();
}
