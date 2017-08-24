using System;
using System.Collections.Generic;

namespace GraphLibrary.Graph
{
    public class SimpleGraph<T> : BaseGraph<T>, ISimpleGraph<T>
    {
        public SimpleGraph()
        {
            
        }

        public SimpleGraph(IEnumerable<Edge<T>> edges)
        {
            foreach (var edge in edges)
                AddEdgeWithVertices(edge);            
        }

        public void AddEdgeBetweenVertices(T id1, T id2, float weight = 0)
        {
            if(!Relations.ContainsKey(id1))
                throw new ArgumentOutOfRangeException(string.Format("Граф не содержит вершины с указанным индексом {0}", id1));
            if(!Relations.ContainsKey(id2))
                throw new ArgumentOutOfRangeException(string.Format("Граф не содержит вершины с указанным индексом {0}", id2));

            Edges.Add(new Edge<T>(id1,id2, weight));
            Relations[id1].Add(id2, weight);
            Relations[id2].Add(id1, weight);
        }

        public void AddEdgeWithVertices(T id1, T id2, float weight = 0)
        {
            Edges.Add(new Edge<T>(id1, id2, weight));
            if (!Relations.ContainsKey(id1))
                Relations.Add(id1, new Dictionary<T, float> { {id2, weight}});
            else
                Relations[id1].Add(id2, weight);

            if (!Relations.ContainsKey(id2))
                Relations.Add(id2, new Dictionary<T, float> { {id1, weight}});   
            else
                Relations[id2].Add(id1, weight);
        }

        public void AddEdgeWithVertices(Edge<T> edge)
        {
            Edges.Add(edge);
            if (!Relations.ContainsKey(edge.Vertex1))
                Relations.Add(edge.Vertex1, new Dictionary<T, float> { {edge.Vertex2, edge.Weight} });
            else
                Relations[edge.Vertex1].Add(edge.Vertex2, edge.Weight);

            if (!Relations.ContainsKey(edge.Vertex2))
                Relations.Add(edge.Vertex2, new Dictionary<T, float> { {edge.Vertex1, edge.Weight} });   
            else
                Relations[edge.Vertex2].Add(edge.Vertex1, edge.Weight);
        }       
    }
}
