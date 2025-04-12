using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestRouteOptimizer.Core.DTOs
{
    public class ShortestPathData
    {
        public List<string> NodeNames { get; set; } = new List<string>();
        public int Distance { get; set; }
    }
}
