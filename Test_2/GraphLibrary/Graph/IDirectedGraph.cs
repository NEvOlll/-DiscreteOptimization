using System.Collections.Generic;

namespace GraphLibrary.Graph
{
    public interface IDirectedGraph<T>: IGraph<T>
    {
        void AddEdgeBetweenVerticesFromV1ToV2(T id1, T id2, float weight = 0);
        void AddEdgeWithVerticesFromV1ToV2(T id1, T id2, float weight = 0);
        void AddEdgeWithVerticesFromV1ToV2(Edge<T> edge);

        IEnumerable<Edge<T>> GetInputEdges(T vertexId);
    }
}
