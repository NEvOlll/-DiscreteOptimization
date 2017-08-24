using GraphLibrary.Graph;
using GraphLibrary.ThreeSearcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GraphLibrary.Test.Unit
{
    [TestClass]
    public class BreadthFirstSearchTests
    {
        [TestMethod]
        public void CorrectEdgesInThree()
        {
            var e12 = new Edge<int>(1, 2);
            var e13 = new Edge<int>(1, 3);
            var e24 = new Edge<int>(2, 4);                        
            var e34 = new Edge<int>(3, 4);
            var e35 = new Edge<int>(3, 5);
            var e36 = new Edge<int>(3, 6);
            var e47 = new Edge<int>(4, 7);
            var e48 = new Edge<int>(4, 8);
            var e56 = new Edge<int>(5, 6);
            var e59 = new Edge<int>(5, 9);
            var e69 = new Edge<int>(6, 9);
            var e78 = new Edge<int>(7, 8);
            var edges = new List<Edge<int>> { e12, e13, e24, e34, e35, e36, e47, e48, e56, e59, e69, e78 };
            var graph = new SimpleGraph<int>(edges);
            var dfs = new BreadthFirstSearch<int>(graph);

            var three = dfs.GetThreeFromVertex(1);

            Assert.IsTrue(three.IsContainsEdge(e12));
            Assert.IsTrue(three.IsContainsEdge(e24));
            Assert.IsTrue(three.IsContainsEdge(e47));
            Assert.IsTrue(three.IsContainsEdge(e48));
            Assert.IsTrue(three.IsContainsEdge(e13));
            Assert.IsTrue(three.IsContainsEdge(e35));
            Assert.IsTrue(three.IsContainsEdge(e36));
            Assert.IsTrue(three.IsContainsEdge(e59));
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
            var dfs = new BreadthFirstSearch<int>(graph);

            var three = dfs.GetThreeFromVertex(1);

            Assert.IsTrue(three.GetCountOfEdges() == 8);
        }
    }
}
