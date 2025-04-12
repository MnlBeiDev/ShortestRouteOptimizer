using ShortestRouteOptimizer.Core.DTOs;
using System.Collections.Generic;

namespace ShortestRouteOptimizer.Data
{
    public static class SampleGraphData
    {
        public static List<Node> GetNodes()
        {
            return new List<Node>
        {
            new Node { Name = "A", Edges = new List<Edge> { new Edge { Target = "B", Distance = 4 }, new Edge { Target = "C", Distance = 6 } } },
            new Node { Name = "B", Edges = new List<Edge> { new Edge { Target = "F", Distance = 2 } } },
            new Node { Name = "C", Edges = new List<Edge> { new Edge { Target = "D", Distance = 8 } } },
            new Node { Name = "D", Edges = new List<Edge> { new Edge { Target = "G", Distance = 1 } } },
            new Node { Name = "E", Edges = new List<Edge> { new Edge { Target = "B", Distance = 2 }, new Edge { Target = "F", Distance = 3 }, new Edge { Target = "D", Distance = 4 } , new Edge { Target ="I", Distance = 8} } },
            new Node { Name = "F", Edges = new List<Edge> { new Edge { Target = "G", Distance = 4 }, new Edge { Target = "H", Distance = 6 } } },
            new Node { Name = "G", Edges = new List<Edge> { new Edge { Target = "H", Distance = 5} ,new Edge { Target = "I", Distance = 5 } } },
            new Node { Name = "H", Edges = new List<Edge> () }, /*{ new Edge { Target = "I", Distance = 8 } } },*/
            new Node { Name = "I", Edges = new List<Edge>() }
        };
        }
    }
}