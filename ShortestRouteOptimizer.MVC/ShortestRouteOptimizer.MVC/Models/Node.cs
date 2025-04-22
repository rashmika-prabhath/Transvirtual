using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShortestRouteOptimizer.MVC.Models
{
    public class Node
    {
        public string Name { get; set; }
        public Dictionary<Node, int> Neighbors { get; set; } = new Dictionary<Node, int>();
    }
}