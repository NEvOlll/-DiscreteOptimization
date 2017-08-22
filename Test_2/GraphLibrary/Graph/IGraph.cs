using System.Collections.Generic;

namespace GraphLibrary.Graph
{
    public interface IGraph<T>
    {
        void AddVertexWithId(T id);
        
        IEnumerable<T> GetVertices();
        IEnumerable<Edge<T>> GetEdges();
        
        IEnumerable<T> GetRelatedVertices(T id);

        bool IsContainsEdge(Edge<T> edge);

        int GetCountOfVertices();
        int GetCountOfEdges();

        int? GetDistanceBetweenVertices(T vertexId1, T vertexId2);
    }
}
