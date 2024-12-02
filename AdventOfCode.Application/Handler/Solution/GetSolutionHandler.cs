using AdventOfCode.Application.Handler.Solution.Model;
using AdventOfCode.Application.Result;
using AdventOfCode.Application.Solution.Abstractions;
using MediatR;
using System.Reflection;

using static AdventOfCode.Application.Result.AdventResult<object>;

namespace AdventOfCode.Application.Handler.Solution;

public class GetSolutionHandler : IRequestHandler<GetSolutionCommand, AdventResult<object>>
{
    public async Task<AdventResult<object>> Handle(GetSolutionCommand request, CancellationToken cancellationToken)
    {
        // Try and find the correct assembly
        var types = Assembly.GetExecutingAssembly().GetTypes()
                               .Where(t => t.Namespace.StartsWith($"AdventOfCode.Application.Solution._{request.Year}.Day{request.Day:00}"))
                               .ToList();

        if(types.Count == 0) 
        {
            return Failure(new AdventError(0003, "No solutions available for this year and day"));
        }

        var type   = types.First(c => c.Name == "Solution");
        var obj    = Activator.CreateInstance(type); 
        var method = type.GetMethod(request.Part == 1 ? "PartOne" : "PartTwo");

        return (AdventResult<object>)method.Invoke(obj, []);
    }
}
