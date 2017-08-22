using System;
using System.Collections.Generic;

namespace GraphLibrary.Graph
{
    public class DirectedGraph<T> :BaseGraph<T>, IDirectedGraph<T>
    {
        public void AddEdgeBetweenVerticesFromV1ToV2(T id1, T id2, int weight = 0)
        {
            if (!Relations.ContainsKey(id1))
                throw new ArgumentOutOfRangeException(string.Format("Граф не содержит вершины с указанным индексом {0}", id1));
            if (!Relations.ContainsKey(id2))
                throw new ArgumentOutOfRangeException(string.Format("Граф не содержит вершины с указанным индексом {0}", id2));

            Edges.Add(new Edge<T>(id1, id2, weight));
            Relations[id1].Add(id2, weight);
        }

        public void AddEdgeWithVerticesFromV1ToV2(T id1, T id2, int weight = 0)
        {
            Edges.Add(new Edge<T>(id1, id2, weight));
            if (!Relations.ContainsKey(id1))
                Relations.Add(id1, new Dictionary<T, int>() { {id2, weight} });
            else
                Relations[id1].Add(id2, weight);
        }

        public void AddEdgeWithVerticesFromV1ToV2(Edge<T> edge)
        {
            Edges.Add(edge);
            if (!Relations.ContainsKey(edge.Vertex1))
                Relations.Add(edge.Vertex1, new Dictionary<T, int> { {edge.Vertex2, edge.Weight} });
            else
                Relations[edge.Vertex1].Add(edge.Vertex2, edge.Weight);
        }
    }
}
