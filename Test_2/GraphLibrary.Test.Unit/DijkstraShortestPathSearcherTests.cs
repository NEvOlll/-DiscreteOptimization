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
            var graphForSPS = new SimpleGraph<int>();
            var edge122 = new Edge<int>(1, 2, 2);
            graphForSPS.AddEdgeWithVertices(edge122);
            var edge133 = new Edge<int>(1, 3, 3);
            graphForSPS.AddEdgeWithVertices(edge133);
            var edge144 = new Edge<int>(1, 4, 4);
            graphForSPS.AddEdgeWithVertices(edge144);
            var edge243 = new Edge<int>(2, 4, 3);
            graphForSPS.AddEdgeWithVertices(edge243);
            var edge342 = new Edge<int>(3, 4, 2);
            graphForSPS.AddEdgeWithVertices(edge342);
            var edge354 = new Edge<int>(3, 5, 4);
            graphForSPS.AddEdgeWithVertices(edge354);
            var edge365 = new Edge<int>(3, 6, 5);
            graphForSPS.AddEdgeWithVertices(edge365);
            var edge454 = new Edge<int>(4, 6, 4);
            graphForSPS.AddEdgeWithVertices(edge454);
            var edge562 = new Edge<int>(5, 6, 2);
            graphForSPS.AddEdgeWithVertices(edge562);
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
            var graphForSPS = new DirectedGraph<int>();
            var edge121 = new Edge<int>(1, 2, 1);
            graphForSPS.AddEdgeWithVerticesFromV1ToV2(edge121);
            var edge132 = new Edge<int>(1, 3, 2);
            graphForSPS.AddEdgeWithVerticesFromV1ToV2(edge132);
            var edge2410 = new Edge<int>(2, 4, 10);
            graphForSPS.AddEdgeWithVerticesFromV1ToV2(edge2410);
            var edge256 = new Edge<int>(2, 5, 6);
            graphForSPS.AddEdgeWithVerticesFromV1ToV2(edge256);
            var edge32n3 = new Edge<int>(3, 2, -3);
            graphForSPS.AddEdgeWithVerticesFromV1ToV2(edge32n3);
            var edge35n1 = new Edge<int>(3, 5, -1);
            graphForSPS.AddEdgeWithVerticesFromV1ToV2(edge35n1);
            var edge454 = new Edge<int>(4, 5, 4);
            graphForSPS.AddEdgeWithVerticesFromV1ToV2(edge454);
            var edge54n2 = new Edge<int>(5, 4, -2);
            graphForSPS.AddEdgeWithVerticesFromV1ToV2(edge54n2);
            var sps = new DijkstraShortestPathSearcher<int>(graphForSPS);

            var sp = sps.GetShortestPathBetween(1, 5);

            Assert.AreEqual(sp[3], 1);
            Assert.IsTrue(sp.Keys.Contains(5));
            Assert.AreEqual(sp[5], 3);
        }
    }
}
