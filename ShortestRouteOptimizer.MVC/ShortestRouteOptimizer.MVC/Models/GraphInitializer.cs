using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShortestRouteOptimizer.MVC.Models
{
    public static class GraphInitializer
    {
        public static Graph InitializeGraph()
        {
            var graph = new Graph();
            graph.AddEdge("A", "B", 4, true);
            graph.AddEdge("A", "C", 6, true);
            graph.AddEdge("B", "F", 2, true);
            graph.AddEdge("C", "D", 8, true);
            graph.AddEdge("D", "G", 1, true);
            graph.AddEdge("E", "B", 2, false);
            graph.AddEdge("D", "E", 4, true);
            graph.AddEdge("F", "E", 3, true);
            graph.AddEdge("F", "H", 6, true);
            graph.AddEdge("G", "H", 5, true);
            graph.AddEdge("G", "F", 4, true);
            graph.AddEdge("G", "I", 5, true);
            graph.AddEdge("E", "I", 8, true);
            return graph;
        }
    }
}