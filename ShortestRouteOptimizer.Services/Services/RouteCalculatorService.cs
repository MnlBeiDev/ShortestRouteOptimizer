using ShortestRouteOptimizer.Core.DTOs;
using ShortestRouteOptimizer.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestRouteOptimizer.Services
{
    public class RouteCalculatorService : IRouteCalculatorService
    {
        //public ShortestPathDataDto ShortestPath(string fromNodeName, string toNodeName, List<Node> nodes)
        //{
        //    var unvisited = new HashSet<string>(nodes.Select(n => n.Name));
        //    var distances = nodes.ToDictionary(n => n.Name, n => int.MaxValue);
        //    var previous = new Dictionary<string, string>();

        //    distances[fromNodeName] = 0;

        //    while (unvisited.Any())
        //    {
        //        var current = unvisited.OrderBy(n => distances[n]).First();
        //        unvisited.Remove(current);

        //        if (current == toNodeName) break;

        //        var currentNode = nodes.First(n => n.Name == current);

        //        foreach (var edge in currentNode.Edges)
        //        {
        //            if (!unvisited.Contains(edge.Target)) continue;

        //            int alt = distances[current] + edge.Distance;
        //            if (alt < distances[edge.Target])
        //            {
        //                distances[edge.Target] = alt;
        //                previous[edge.Target] = current;
        //            }
        //        }
        //    }

        //    var path = new List<string>();
        //    string step = toNodeName;

        //    while (previous.ContainsKey(step))
        //    {
        //        path.Insert(0, step);
        //        step = previous[step];
        //    }

        //    if (step == fromNodeName)
        //    {
        //        path.Insert(0, fromNodeName);
        //        return new ShortestPathDataDto { NodeNames = path, Distance = distances[toNodeName] };
        //    }

        //    return new ShortestPathDataDto(); // No path
        //}

        public ShortestPathData GetShortestPath(string fromNode, string toNode, List<Node> graph)
        {
            if (string.IsNullOrWhiteSpace(fromNode) || string.IsNullOrWhiteSpace(toNode))
                throw new ArgumentException("From and To nodes must be provided.");

            var nodeLookup = graph.ToDictionary(n => n.Name);
            if (!nodeLookup.ContainsKey(fromNode) || !nodeLookup.ContainsKey(toNode))
                throw new ArgumentException("Invalid FROM or TO node specified.");

            var distances = graph.ToDictionary(n => n.Name, n => int.MaxValue);
            var previous = new Dictionary<string, string>();
            var unvisited = new HashSet<string>(nodeLookup.Keys);

            distances[fromNode] = 0;

            while (unvisited.Any())
            {
                var current = GetClosestUnvisitedNode(unvisited, distances);
                if (current == toNode || distances[current] == int.MaxValue)
                    break;

                unvisited.Remove(current);
                var currentNode = nodeLookup[current];

                foreach (var edge in currentNode.Edges)
                {
                    if (!nodeLookup.ContainsKey(edge.Target)) continue;

                    int newDist = distances[current] + edge.Distance;
                    if (newDist < distances[edge.Target])
                    {
                        distances[edge.Target] = newDist;
                        previous[edge.Target] = current;
                    }
                }
            }

            return BuildResult(toNode, previous, distances);
        }

        private string GetClosestUnvisitedNode(HashSet<string> unvisited, Dictionary<string, int> distances)
        {
            return unvisited
                .OrderBy(n => distances[n])
                .First();
        }

        private ShortestPathData BuildResult(string toNode, Dictionary<string, string> previous, Dictionary<string, int> distances)
        {
            var path = new List<string>();
            string current = toNode;

            while (!string.IsNullOrEmpty(current))
            {
                path.Insert(0, current);
                previous.TryGetValue(current, out current);
            }

            return new ShortestPathData
            {
                NodeNames = path,
                Distance = distances[toNode] == int.MaxValue ? -1 : distances[toNode]
            };
        }
    }
}
