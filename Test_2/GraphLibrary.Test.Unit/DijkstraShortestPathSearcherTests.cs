using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary.Graph;
using GraphLibrary.ShortestPathSearcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphLibrary.Test.Unit
{
    [TestClass]
    public class DijkstraShortestPathSearcherTests
    {
        [TestMethod]
        public void CorrectSearchShortestPath()
        {
            //2-4-6
            //|/|/|
            //1-3-5            
            var edge122 = new Edge<int>(1, 2, 2);
            var edge133 = new Edge<int>(1, 3, 3);
            var edge144 = new Edge<int>(1, 4, 4);
            var edge243 = new Edge<int>(2, 4, 3);
            var edge342 = new Edge<int>(3, 4, 2);
            var edge354 = new Edge<int>(3, 5, 4);
            var edge365 = new Edge<int>(3, 6, 5);
            var edge454 = new Edge<int>(4, 6, 4);
            var edge562 = new Edge<int>(5, 6, 2);
            var edges = new List<Edge<int>> { edge122, edge133, edge144, edge243, edge342, edge354, edge365, edge454, edge562 };
            var graphForSPS = new SimpleGraph<int>(edges);
            var sps = new FordBellmanShortestPathSearcher<int>(graphForSPS);

            var sp = sps.GetShortestPathBetween(1, 6);

            Assert.IsTrue(sp.Keys.Contains(6));
            Assert.AreEqual(sp[6], 3);
            Assert.IsTrue(sp.Keys.Contains(3));
            Assert.AreEqual(sp[3], 1);
        }

        [TestMethod]
        public void CorrectSearchShortestPathWithNegativeEdges()
        {
            //  3---5
            // /|  /|
            //1 | / |
            // \|/  |
            //  2---4            
            var edge121 = new Edge<int>(1, 2, 1);
            var edge132 = new Edge<int>(1, 3, 2);
            var edge2410 = new Edge<int>(2, 4, 10);
            var edge256 = new Edge<int>(2, 5, 6);
            var edge32n3 = new Edge<int>(3, 2, -3);
            var edge35n1 = new Edge<int>(3, 5, -1);
            var edge454 = new Edge<int>(4, 5, 4);
            var edge54n2 = new Edge<int>(5, 4, -2);
            var edges = new List<Edge<int>> { edge121, edge132, edge2410, edge256, edge32n3, edge35n1, edge454, edge54n2 };
            var graphForSPS = new DirectedGraph<int>(edges);
            var sps = new DijkstraShortestPathSearcher<int>(graphForSPS);

            var sp = sps.GetShortestPathBetween(1, 5);

            Assert.AreEqual(sp[3], 1);
            Assert.IsTrue(sp.Keys.Contains(5));
            Assert.AreEqual(sp[5], 3);
        }
    }
}
