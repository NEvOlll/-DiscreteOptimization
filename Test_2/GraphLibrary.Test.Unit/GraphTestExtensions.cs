using GraphLibrary.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Test.Unit
{
    static class GraphTestExtensions
    {
        public static bool IsContainsEdge<T>(this IGraph<T> graph, T vertexId1, T vertexId2, float weight = 0)
        {
            return graph.GetEdges().Any(x => (x.Vertex1.Equals(vertexId1) && x.Vertex2.Equals(vertexId2) && x.Weight == weight) 
                || (x.Vertex2.Equals(vertexId1) && x.Vertex1.Equals(vertexId2) && x.Weight == weight));
        }

        public static bool IsContainsEdge<T>(this IGraph<T> graph, Edge<T> edge)
        {
            return graph.GetEdges().Any(x => x.Equals(edge));
        }
    }
}
