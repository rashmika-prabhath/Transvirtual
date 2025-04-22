using System.Collections.Generic;

namespace ShortestRouteOptimizer.Models
{
    public class Node
    {
        public string Name { get; set; }
        public Dictionary<Node, int> Neighbors { get; set; } = new Dictionary<Node, int>();
    }
}