using AdventOfCode.Application.Result;
using AdventOfCode.Application.Solution.Abstractions;

using static AdventOfCode.Application.Result.AdventResult<object>;

namespace AdventOfCode.Application.Solution._2024.Day01;

public class Solution : ISolution
{
    public AdventResult<object> PartOne()
    {
        var input = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}/Solution/2024/Day01/Input.txt").ReadToEnd();

        var column1 = input.Split('\n').Select(l => long.Parse(l.Split("   ")[0])).Order();
        var column2 = input.Split('\n').Select(l => long.Parse(l.Split("   ")[1])).Order();

        long answer = Enumerable.Zip(column1, column2)
                               .Select(p => Math.Abs(p.First - p.Second))
                               .Sum();

        return Success(answer);
    }

    public AdventResult<object> PartTwo()
    {
        var input = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}/Solution/2024/Day01/Input.txt").ReadToEnd();

        // Create list 1
        var column1 = input.Split('\n').Select(l => Int32.Parse(l.Split("   ")[0]));

        // Create a dictionary for the amount of each value
        var dictionary = new Dictionary<int, int>();
        foreach (var item in input.Split('\n').Select(l => int.Parse(l.Split("   ")[1])))
        {
            if (!dictionary.TryAdd(item, 1)) 
            {
                dictionary[item]++;
            }
        };

        // Sum all the dictionary values that are in list 1
        var value = 0;
        foreach (var item in column1)
        {
            value += dictionary.ContainsKey(item) ? item * dictionary[item] : 0;
        }
        return Success(value);
    }
}
