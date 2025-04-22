using ShortestRouteOptimizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestRouteOptimizer
{
    namespace ShortestPathConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var graph = new Graph();
                InitializeGraph(graph);
                var calculator = new ShortestPathCalculator();

                Console.WriteLine("Shortest Path Console App");
                Console.Write("Enter start node: ");
                string from = Console.ReadLine();

                Console.Write("Enter end node: ");
                string to = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
                {
                    Console.WriteLine("Both node names are required.");
                    return;
                }

                if (!graph.Nodes.ContainsKey(from) || !graph.Nodes.ContainsKey(to))
                {
                    Console.WriteLine("One or both of the nodes do not exist.");
                    return;
                }

                var result = calculator.CalculateShortestPath(from, to, graph);

                Console.WriteLine($"\nShortest path from {from} to {to}: {string.Join(" -> ", result.NodeNames)}");
                Console.WriteLine($"Total distance: {result.Distance}");
            }

            private static void InitializeGraph(Graph graph)
            {
                graph.AddEdge("A", "B", 4);
                graph.AddEdge("B", "A", 4);
                graph.AddEdge("A", "C", 6);
                graph.AddEdge("C", "A", 6);
                graph.AddEdge("B", "F", 2);
                graph.AddEdge("F", "B", 2);
                graph.AddEdge("C", "D", 8);
                graph.AddEdge("D", "C", 8);
                graph.AddEdge("D", "G", 1);
                graph.AddEdge("G", "D", 1);
                graph.AddEdge("E", "B", 2);
                graph.AddEdge("D", "E", 4);
                graph.AddEdge("E", "D", 4);
                graph.AddEdge("F", "E", 3);
                graph.AddEdge("E", "F", 3);
                graph.AddEdge("F", "H", 6);
                graph.AddEdge("H", "F", 6);
                graph.AddEdge("G", "H", 5);
                graph.AddEdge("H", "G", 5);
                graph.AddEdge("G", "F", 4);
                graph.AddEdge("F", "G", 4);
                graph.AddEdge("G", "I", 5);
                graph.AddEdge("I", "G", 5);
                graph.AddEdge("E", "I", 8);
                graph.AddEdge("I", "E", 8);
            }
        }
    }
}
