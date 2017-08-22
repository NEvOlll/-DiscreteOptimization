using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary;
using GraphLibrary.Graph;
using GraphLibrary.ShortestPathSearcher;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var myGraph = new SimpleGraph<int>();
            myGraph.AddEdgeWithVertices(1, 2);
            myGraph.AddEdgeWithVertices(1, 4);
            myGraph.AddEdgeWithVertices(2, 3);
            myGraph.AddEdgeWithVertices(2, 4);
            myGraph.AddEdgeWithVertices(2, 5);
            myGraph.AddEdgeWithVertices(3, 5);
            myGraph.AddEdgeWithVertices(4, 6);
            myGraph.AddEdgeWithVertices(4, 7);
            myGraph.AddEdgeWithVertices(5, 6);
            myGraph.AddEdgeWithVertices(5, 8);
            myGraph.AddEdgeWithVertices(6, 7);
            myGraph.AddEdgeWithVertices(6, 8);
            myGraph.AddEdgeWithVertices(7, 8);
            myGraph.AddEdgeWithVertices(7, 9);
            myGraph.AddEdgeWithVertices(8, 9);

            var dfs = new DeepFirstSearch<int>(myGraph);
            var dThree = dfs.GetDThree(1);

            var bfs = new BreadthFirstSearch<int>(myGraph);
            var bThree = bfs.GetBThree(1);

            var eps = new EulerianPathSearch<int>(myGraph);
            var ep = eps.GetPath();

            //2-4-6
            //|/|/|
            //1-3-5
            var graphFoMSTS = new SimpleGraph<int>();
            graphFoMSTS.AddEdgeWithVertices(1, 2, 2);
            graphFoMSTS.AddEdgeWithVertices(1, 3, 3);
            graphFoMSTS.AddEdgeWithVertices(1, 4, 4);

            graphFoMSTS.AddEdgeWithVertices(2, 4, 3);

            graphFoMSTS.AddEdgeWithVertices(3, 4, 2);
            graphFoMSTS.AddEdgeWithVertices(3, 5, 4);
            graphFoMSTS.AddEdgeWithVertices(3, 6, 5);

            graphFoMSTS.AddEdgeWithVertices(4, 6, 4);
            graphFoMSTS.AddEdgeWithVertices(5, 6, 2);
            var msts = new MinimumSpanningTreeSearch<int>(graphFoMSTS);
            var mst = msts.GetMinimumSpanningTree();

            var sps = new FordBellmanShortestPathSearcher<int>(graphFoMSTS);
            var sp = sps.GetShortestPathBetween(1, 6);
        }
    }
}
