using ShortestRouteOptimizer.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShortestRouteOptimizer.MVC.Controllers
{
    public class PathController : Controller
    {
        private readonly Graph _graph = GraphInitializer.InitializeGraph();
        private readonly ShortestPathCalculator _calculator = new ShortestPathCalculator();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Nodes = _graph.Nodes.Keys;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string from, string to)
        {
            ViewBag.Nodes = _graph.Nodes.Keys;

            if (!_graph.Nodes.ContainsKey(from) || !_graph.Nodes.ContainsKey(to))
            {
                ViewBag.Error = "Invalid nodes.";
                return View();
            }

            var result = _calculator.CalculateShortestPath(from, to, _graph);
            ViewBag.Path = string.Join(" ➝ ", result.NodeNames);
            ViewBag.Distance = result.Distance;

            return View();
        }
    }

}