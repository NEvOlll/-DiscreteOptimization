using System;
using System.Collections.Generic;
using System.Linq;
using GraphLibrary.Graph;

namespace GraphLibrary
{
    public class TopologicalSorting<T>
    {
        private readonly IDirectedGraph<T> _graph;
        public TopologicalSorting(IDirectedGraph<T> graph)
        {
            if(graph == null)
                throw new ArgumentNullException("graph");
            _graph = graph;
        }

        public Dictionary<T, int> GetSortedVertices()
        {
            var maxNumber = _graph.GetCountOfVertices();
            var vertices = _graph.GetVertices().ToList();
            var edges = _graph.GetEdges();
            var indexes = vertices.ToDictionary(x => x, x => 0);
            var outDeg = vertices.ToDictionary(x => x, x => 0);
            foreach (var edge in edges)            
                outDeg[edge.Vertex1]++;
            var zeroDegQueue = new Queue<T>(outDeg.Where(x => x.Value == 0).Select(x => x.Key));
            while (zeroDegQueue.Any())
            {
                var currentVertex = zeroDegQueue.Dequeue();
                indexes[currentVertex] = maxNumber--;
                foreach (var inputEdge in _graph.GetInputEdges(currentVertex))
                {
                    outDeg[inputEdge.Vertex1]--;
                    if(outDeg[inputEdge.Vertex1] == 0)
                        zeroDegQueue.Enqueue(inputEdge.Vertex1);
                }                
                
            }
            return indexes;
        }
    }
}
