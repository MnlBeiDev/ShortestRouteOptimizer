using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestRouteOptimizer.Core.DTOs
{
    public class Node
    {
        public string Name { get; set; }
        public List<Edge> Edges { get; set; } = new List<Edge>();
    }

}
