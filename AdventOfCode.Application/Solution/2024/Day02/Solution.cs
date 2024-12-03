using AdventOfCode.Application.Result;
using AdventOfCode.Application.Solution.Abstractions;

using static AdventOfCode.Application.Result.AdventResult<object>;

namespace AdventOfCode.Application.Solution._2024.Day02;

public class Solution : ISolution
{
    public AdventResult<object> PartOne()
    {
        // Get the reports
        var input = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}/Solution/2024/Day02/Input.txt").ReadToEnd();
        var lines = input.Split('\n');
        var reports = lines.Select(l => l.Split(' ').Select(i => int.Parse(i)));

        // Get the answer
        var result = 0;
        foreach (var report in reports)
        {
            var pairs = Enumerable.Zip(report, report.Skip(1));

            if(pairs.All(p => 0 < p.Second - p.First && p.Second - p.First < 4) || pairs.All(p => 0 < p.First - p.Second && p.First - p.Second < 4)) 
            {
                result++;
            }
        }

        return Success(result);
    }

    public AdventResult<object> PartTwo()
    {
        // Get the reports
        var input = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}/Solution/2024/Day02/Input.txt").ReadToEnd();
        var lines = input.Split('\n');
        var reports = lines.Select(l => l.Split(' ').Select(i => int.Parse(i)));

        // Get the answer
        var result = 0;
        foreach (var report in reports)
        {
            var possibleReports = from i in Enumerable.Range(0, report.Count() + 1)
                                  let prefix = report.Take(i - 1)
                                  let suffix = report.Skip(i)
                                  select Enumerable.Concat(prefix, suffix);

            foreach (var r in possibleReports)
            {
                var pairs = Enumerable.Zip(r, r.Skip(1));

                if (pairs.All(p => 0 < p.Second - p.First && p.Second - p.First < 4) || pairs.All(p => 0 < p.First - p.Second && p.First - p.Second < 4))
                {
                    result++;
                    break;
                }
            }
        }

        return Success(result);
    }
}
