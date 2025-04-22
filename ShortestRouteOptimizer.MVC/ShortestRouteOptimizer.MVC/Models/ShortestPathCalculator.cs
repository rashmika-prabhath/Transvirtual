using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShortestRouteOptimizer.MVC.Models
{
    public class ShortestPathCalculator
    {
        public ShortestPathData CalculateShortestPath(string from, string to, Graph graph)
        {
            var distances = new Dictionary<Node, int>();
            var previous = new Dictionary<Node, Node>();
            var unvisited = new List<Node>();

            foreach (var node in graph.Nodes.Values)
            {
                distances[node] = int.MaxValue;
                previous[node] = null;
                unvisited.Add(node);
            }

            distances[graph.Nodes[from]] = 0;

            while (unvisited.Count > 0)
            {
                unvisited.Sort((a, b) => distances[a] - distances[b]);
                var current = unvisited[0];
                unvisited.RemoveAt(0);

                if (current.Name == to) break;

                foreach (var neighbor in current.Neighbors)
                {
                    int alt = distances[current] + neighbor.Value;
                    if (alt < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = alt;
                        previous[neighbor.Key] = current;
                    }
                }
            }

            var path = new List<string>();
            var nodePath = graph.Nodes[to];

            while (nodePath != null)
            {
                path.Add(nodePath.Name);
                nodePath = previous[nodePath];
            }

            path.Reverse();

            return new ShortestPathData
            {
                NodeNames = path,
                Distance = distances[graph.Nodes[to]]
            };
        }
    }
}