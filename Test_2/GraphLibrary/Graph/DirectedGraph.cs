using System;
using System.Collections.Generic;

namespace GraphLibrary.Graph
{
    public class DirectedGraph<T> :BaseGraph<T>, IDirectedGraph<T>
    {
        private readonly Dictionary<T, List<Edge<T>>> _inputEdgesOfVertex;

        public DirectedGraph()
        {
            _inputEdgesOfVertex = new Dictionary<T, List<Edge<T>>>();
        }

        public DirectedGraph(IEnumerable<Edge<T>> edges)
            :this()
        {
            foreach (var edge in edges)
                AddEdgeWithVerticesFromV1ToV2(edge);
        }

        public void AddEdgeBetweenVerticesFromV1ToV2(T vertexId1, T vertexId2, float weight = 0)
        {
            if (!Relations.ContainsKey(vertexId1))
                throw new ArgumentOutOfRangeException(string.Format("Граф не содержит вершины с указанным индексом {0}", vertexId1));
            if (!Relations.ContainsKey(vertexId2))
                throw new ArgumentOutOfRangeException(string.Format("Граф не содержит вершины с указанным индексом {0}", vertexId2));

            //после того как убедились что обе вершины существуют в графе, создаем новое ребор между ними
            var newEdge = new Edge<T>(vertexId1, vertexId2, weight);
            EdgeAppendant(newEdge);
        }

        public void AddEdgeWithVerticesFromV1ToV2(T vertexId1, T vertexId2, float weight = 0)
        {
            VertexChecker(vertexId1, vertexId2);
            AddEdgeBetweenVerticesFromV1ToV2(vertexId1, vertexId2, weight);
        }

        public void AddEdgeWithVerticesFromV1ToV2(Edge<T> edge)
        {
            VertexChecker(edge.Vertex1, edge.Vertex2);
            EdgeAppendant(edge);
        }

        private void VertexChecker(T vertexId1, T vertexId2)
        {
            if (!Relations.ContainsKey(vertexId1))
                Relations.Add(vertexId1, new Dictionary<T, float>());
            if (!Relations.ContainsKey(vertexId2))
                Relations.Add(vertexId2, new Dictionary<T, float>());

            if (!_inputEdgesOfVertex.ContainsKey(vertexId1))
                _inputEdgesOfVertex.Add(vertexId1, new List<Edge<T>>());
            if (!_inputEdgesOfVertex.ContainsKey(vertexId2))
                _inputEdgesOfVertex.Add(vertexId2, new List<Edge<T>>());
        }

        private void EdgeAppendant(Edge<T> newEdge)
        {
            //добавляем созданное ребро в список ребер
            Edges.Add(newEdge);
            //добавляем в список исходящих связей, ссылку из вершины 1 на вершину 2
            Relations[newEdge.Vertex1].Add(newEdge.Vertex2, newEdge.Weight);
            //обновляем список входящих связей в вершину 2
            _inputEdgesOfVertex[newEdge.Vertex2].Add(newEdge);
        }

        public IEnumerable<Edge<T>> GetInputEdges(T vertexId)
        {
            return _inputEdgesOfVertex[vertexId];
        }

        public override void AddVertexWithId(T vertexId)
        {
            if (!_inputEdgesOfVertex.ContainsKey(vertexId))
                _inputEdgesOfVertex.Add(vertexId, new List<Edge<T>>());
            base.AddVertexWithId(vertexId);
        }
    }
}
