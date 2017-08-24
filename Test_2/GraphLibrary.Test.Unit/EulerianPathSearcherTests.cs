using System.Collections.Generic;
using System.Linq;
using GraphLibrary.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphLibrary.Test.Unit
{
    [TestClass]
    public class EulerianPathSearcherTests
    {
        [TestMethod]
        public void CorrectPath()
        {            
            var sourceEdges = new List<Edge<int>>
            {
                new Edge<int>(1,2), new Edge<int>(1,4),
                new Edge<int>(2,3), new Edge<int>(2,4), new Edge<int>(2,5),                
                new Edge<int>(3,5),
                new Edge<int>(4,6), new Edge<int>(4,7),                
                new Edge<int>(5,6), new Edge<int>(5,8),
                new Edge<int>(6,7), new Edge<int>(6,8),
                new Edge<int>(7,8), new Edge<int>(7,9), 
                new Edge<int>(8,9)                
            };
            var myGraph = new SimpleGraph<int>(sourceEdges);
            var eps = new EulerianPathSearcher<int>(myGraph);

            var ep = eps.GetPath().ToList();

            var calculatedEdges = new List<Edge<int>>();
            for (var i = 0; i < ep.Count-1; i++)            
                calculatedEdges.Add(new Edge<int>(ep[i], ep[i + 1]));      
      
            //утверждаем что в полученном списке, каждое сходное ребро встречается ровно 1 раз
            Assert.IsTrue(calculatedEdges.All(ce => sourceEdges.Count(se => se.Equals(ce)) == 1));
        }
    }
}
