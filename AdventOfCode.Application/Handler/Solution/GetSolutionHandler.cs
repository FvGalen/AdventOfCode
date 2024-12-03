using AdventOfCode.Application.Handler.Solution.Model;
using AdventOfCode.Application.Result;
using MediatR;
using System.Diagnostics;
using System.Reflection;

using static AdventOfCode.Application.Result.AdventResult<object>;

namespace AdventOfCode.Application.Handler.Solution;

public class GetSolutionHandler : IRequestHandler<GetSolutionCommand, AdventResult<object>>
{
    public async Task<AdventResult<object>> Handle(GetSolutionCommand request, CancellationToken cancellationToken)
    {
        // Try and find the correct assembly
        var types = Assembly.GetExecutingAssembly().GetTypes()
                            .Where(t => t.Namespace != null &&  t.Namespace.StartsWith($"AdventOfCode.Application.Solution._{request.Year}.Day{request.Day:00}"))
                            .ToList();

        if(types.Count == 0) 
        {
            return Failure(new AdventError(0003, "No solutions available for this year and day"));
        }

        // Try and get the solution method
        var type   = types.First(c => c.Name == "Solution");
        var obj    = Activator.CreateInstance(type); 
        var method = type.GetMethod(request.Part == 1 ? "PartOne" : "PartTwo");

        // Run the method
        var sw = new Stopwatch();
        sw.Start();
        var result = (AdventResult<object>)method.Invoke(obj, []);
        sw.Stop();

        // Check for error
        if (result.IsError) 
        {
            return Failure(result.Error!);
        }

        // Return a result object
        return Success(new ResultObject(sw.ElapsedMilliseconds, result.Value!));
    }

    private class ResultObject 
    {
        public long MillisecondsPassed { get; set; }
        public object Result { get; set; }

        public ResultObject(long milliseconds, object result) 
        {
            MillisecondsPassed = milliseconds;
            Result = result;
        }
    }
}
