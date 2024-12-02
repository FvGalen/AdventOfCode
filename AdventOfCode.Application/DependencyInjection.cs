using AdventOfCode.Application.Handler.Solution;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(GetSolutionHandler).Assembly));

        return services;
    }
}
