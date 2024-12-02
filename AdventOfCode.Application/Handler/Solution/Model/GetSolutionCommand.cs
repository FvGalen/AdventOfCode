using AdventOfCode.Application.Result;
using MediatR;

namespace AdventOfCode.Application.Handler.Solution.Model;

public class GetSolutionCommand : IRequest<AdventResult<object>>
{
    public int Year { get; set; }
    public int Day {  get; set; }
    public int Part { get; set; }

    public GetSolutionCommand(int year, int day, int part)
    {
        Year = year;
        Day = day;
        Part = part;
    }
}
