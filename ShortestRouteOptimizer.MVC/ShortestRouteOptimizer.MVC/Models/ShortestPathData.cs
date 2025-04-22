using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShortestRouteOptimizer.MVC.Models
{
    public class ShortestPathData
    {
        public List<string> NodeNames { get; set; }
        public int Distance { get; set; }
    }
}