using ShortestRouteOptimizer.Core.DTOs;
using System.Collections.Generic;

namespace ShortestRouteOptimizer.Core.Interfaces
{
    public interface IRouteCalculatorService
    {
        ShortestPathData GetShortestPath(string fromNode, string toNode, List<Node> graph);
    }
}