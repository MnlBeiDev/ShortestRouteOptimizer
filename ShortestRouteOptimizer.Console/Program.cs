using Autofac;
using ShortestRouteOptimizer.Core.Interfaces;
using ShortestRouteOptimizer.Data;
using ShortestRouteOptimizer.Services;
using System;
internal class Program
{
    static void Main()
    {

        var builder = new ContainerBuilder();

        // Register services
        builder.RegisterType<RouteCalculatorService>()
               .As<IRouteCalculatorService>();

        var container = builder.Build();

        Console.Write("From: ");
        string from = Console.ReadLine();
        Console.Write("To: ");
        string to = Console.ReadLine();

        using (var scope = container.BeginLifetimeScope())
        {
            var routeCalculator = scope.Resolve<IRouteCalculatorService>();

            var graph = SampleGraphData.GetNodes();

            var result = routeCalculator.GetShortestPath(from, to, graph);

            Console.WriteLine($"Path: {string.Join(", ", result.NodeNames)}");
            Console.WriteLine($"Total Distance: {result.Distance}");
            Console.ReadLine();
        }

    }
}