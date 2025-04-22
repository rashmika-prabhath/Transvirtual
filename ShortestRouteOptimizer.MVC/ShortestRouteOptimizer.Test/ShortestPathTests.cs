using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortestRouteOptimizer.MVC.Models;
using System;
using System.Collections.Generic;

namespace ShortestRouteOptimizer.Test
{
    [TestClass]
    public class ShortestPathTests
    {
        [TestMethod]
        public void CalculateShortestPath_Returns_Correct_Path_And_Distance()
        {
            // Arrange
            var nodeA = new Node { Name = "A" };
            var nodeB = new Node { Name = "B" };
            var nodeC = new Node { Name = "C" };
            var nodeD = new Node { Name = "D" };

            nodeA.Neighbors[nodeB] = 2;
            nodeB.Neighbors[nodeC] = 3;
            nodeC.Neighbors[nodeD] = 5;

            var graph = new Graph
            {
                Nodes = new Dictionary<string, Node>
                {
                    { "A", nodeA },
                    { "B", nodeB },
                    { "C", nodeC },
                    { "D", nodeD }
                }
            };

            var calculator = new ShortestPathCalculator();

            // Act
            var result = calculator.CalculateShortestPath("A", "D", graph);

            // Assert
            CollectionAssert.AreEqual(new List<string> { "A", "B", "C", "D" }, result.NodeNames);
            Assert.AreEqual(10, result.Distance);
        }

        [TestMethod]
        public void CalculateShortestPath_Returns_Empty_When_No_Path()
        {
            // Arrange
            var nodeA = new Node { Name = "A" };
            var nodeB = new Node { Name = "B" };
            nodeB.Neighbors[nodeA] = 2; // B ➝ A only (no A ➝ B)

            var graph = new Graph
            {
                Nodes = new Dictionary<string, Node>
                {
                    { "A", nodeA },
                    { "B", nodeB }
                }
            };

            var calculator = new ShortestPathCalculator();

            // Act
            var result = calculator.CalculateShortestPath("A", "B", graph);

            // Assert
            CollectionAssert.AreEqual(new List<string> { "B" }, result.NodeNames);
            Assert.AreEqual(int.MaxValue, result.Distance);
        }

        [TestMethod]
        public void CalculateShortestPath_Returns_SingleNode_When_From_Equals_To()
        {
            // Arrange
            var nodeA = new Node { Name = "A" };

            var graph = new Graph
            {
                Nodes = new Dictionary<string, Node>
                {
                    { "A", nodeA }
                }
            };

            var calculator = new ShortestPathCalculator();

            // Act
            var result = calculator.CalculateShortestPath("A", "A", graph);

            // Assert
            CollectionAssert.AreEqual(new List<string> { "A" }, result.NodeNames);
            Assert.AreEqual(0, result.Distance);
        }
    }
}
