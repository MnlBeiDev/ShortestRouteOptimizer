using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestRouteOptimizer.Core.DTOs
{
   public class Edge
    {
        public string Target { get; set; }
        public int Distance { get; set; }
    }
}
