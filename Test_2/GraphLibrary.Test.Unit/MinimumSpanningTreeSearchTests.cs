using System;
using GraphLibrary.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphLibrary.Test.Unit
{
    [TestClass]
    public class MinimumSpanningTreeSearchTests
    {
        [TestMethod]
        public void CorrectBuildTree()
        {
            //2-4-6
            //|/|/|
            //1-3-5
            var graphFoMSTS = new SimpleGraph<int>();
            var edge122 = new Edge<int>(1, 2, 2);
            graphFoMSTS.AddEdgeWithVertices(edge122);
            var edge133 = new Edge<int>(1, 3, 3);
            graphFoMSTS.AddEdgeWithVertices(edge133);
            var edge144 = new Edge<int>(1, 4, 4);
            graphFoMSTS.AddEdgeWithVertices(edge144);
            var edge243 = new Edge<int>(2, 4, 3);
            graphFoMSTS.AddEdgeWithVertices(edge243);
            var edge342 = new Edge<int>(3, 4, 2);
            graphFoMSTS.AddEdgeWithVertices(edge342);
            var edge354 = new Edge<int>(3, 5, 4);
            graphFoMSTS.AddEdgeWithVertices(edge354);
            var edge365 = new Edge<int>(3, 6, 5);
            graphFoMSTS.AddEdgeWithVertices(edge365);
            var edge454 = new Edge<int>(4, 6, 4);
            graphFoMSTS.AddEdgeWithVertices(edge454);
            var edge562 = new Edge<int>(5, 6, 2);
            graphFoMSTS.AddEdgeWithVertices(edge562);
            var msts = new MinimumSpanningTreeSearch<int>(graphFoMSTS);

            var mst = msts.GetMinimumSpanningTree();

            Assert.IsTrue(mst.IsContainsEdge(edge122));
            Assert.IsTrue(mst.IsContainsEdge(edge342));
            Assert.IsTrue(mst.IsContainsEdge(edge562));
            Assert.IsTrue(mst.IsContainsEdge(edge133));
            Assert.IsTrue(mst.IsContainsEdge(edge354));
        }
    }
}
