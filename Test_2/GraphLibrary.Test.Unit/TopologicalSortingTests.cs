using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphLibrary.Test.Unit
{
    [TestClass]
    public class TopologicalSortingTests
    {
        [TestMethod]
        public void CorrectSort()
        {
            var edges = new List<Edge<int>> { new Edge<int>(1, 2), new Edge<int>(2, 3), new Edge<int>(3, 4) };
            var dg = new DirectedGraph<int>(edges);
            var ts = new TopologicalSorting<int>(dg);

            var sortedVertices = ts.GetSortedVertices();

            Assert.AreEqual(sortedVertices[4], 4);
            Assert.AreEqual(sortedVertices[3], 3);
            Assert.AreEqual(sortedVertices[2], 2);
            Assert.AreEqual(sortedVertices[1], 1);
        }
    }
}
