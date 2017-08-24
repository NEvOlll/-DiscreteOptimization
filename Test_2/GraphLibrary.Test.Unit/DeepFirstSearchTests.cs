using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GraphLibrary.Graph;
using GraphLibrary.ThreeSearcher;
using System.Linq;

namespace GraphLibrary.Test.Unit
{
    [TestClass]
    public class DeepFirstSearchTests
    {
        [TestMethod]
        public void CorrectEdgesInThree()
        {
            var e12 = new Edge<int>(1, 2);
            var e17 = new Edge<int>(1, 7);
            var e23 = new Edge<int>(2, 3);
            var e25 = new Edge<int>(2, 5);
            var e26 = new Edge<int>(2, 6);
            var e34 = new Edge<int>(3, 4);
            var e35 = new Edge<int>(3, 5);
            var e45 = new Edge<int>(4, 5);
            var e67 = new Edge<int>(6, 7);
            var e68 = new Edge<int>(6, 8);
            var e69 = new Edge<int>(6, 9);
            var e89 = new Edge<int>(8, 9);
            var edges = new List<Edge<int>> { e12, e17, e23, e25, e26, e34, e35, e45, e67, e68, e69, e89 };
            var graph = new SimpleGraph<int>(edges);
            var dfs = new DeepFirstSearcher<int>(graph);

            var three = dfs.GetThreeFromVertex(1);

            Assert.IsTrue(three.IsContainsEdge(e17));
            Assert.IsTrue(three.IsContainsEdge(e67));
            Assert.IsTrue(three.IsContainsEdge(e69));
            Assert.IsTrue(three.IsContainsEdge(e89));
            Assert.IsTrue(three.IsContainsEdge(e26));
            Assert.IsTrue(three.IsContainsEdge(e25));
            Assert.IsTrue(three.IsContainsEdge(e45));
            Assert.IsTrue(three.IsContainsEdge(e34));
        }

        [TestMethod]
        public void CorrectCountOfEdgesInThree()
        {
            var e12 = new Edge<int>(1, 2);
            var e17 = new Edge<int>(1, 7);
            var e23 = new Edge<int>(2, 3);
            var e25 = new Edge<int>(2, 5);
            var e26 = new Edge<int>(2, 6);
            var e34 = new Edge<int>(3, 4);
            var e35 = new Edge<int>(3, 5);
            var e45 = new Edge<int>(4, 5);
            var e67 = new Edge<int>(6, 7);
            var e68 = new Edge<int>(6, 8);
            var e69 = new Edge<int>(6, 9);
            var e89 = new Edge<int>(8, 9);
            var edges = new List<Edge<int>> { e12, e17, e23, e25, e26, e34, e35, e45, e67, e68, e69, e89 };
            var graph = new SimpleGraph<int>(edges);
            var dfs = new DeepFirstSearcher<int>(graph);

            var three = dfs.GetThreeFromVertex(1);

            Assert.IsTrue(three.GetCountOfEdges() == 8);
        }
    }
}
