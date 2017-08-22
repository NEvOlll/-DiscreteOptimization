using GraphLibrary.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphLibrary
{
    public class DijkstraShortestPathSearcher<T>
    {
        private readonly IGraph<T> _graph;
        private readonly IList<T> _vertices;
        private IDictionary<T, int?> _distances;
        public DijkstraShortestPathSearcher(IGraph<T> graph)
        {
            if (graph == null)
                throw new ArgumentNullException("graph");
            _graph = graph;
            _vertices = _graph.GetVertices().ToList();
        }

        public Dictionary<T, T> GetShortestPathBetween(T vertexId1, T vertexId2)
        {
            var startVertex = vertexId1;
            var countOfVertices = _graph.GetCountOfVertices();
            _distances = _vertices.ToDictionary(v => v, v => _graph.GetDistanceBetweenVertices(startVertex, v));

            var path = _distances
                .Where(x => x.Value.HasValue)
                .ToDictionary(v => v.Key, v => startVertex);

            _vertices.Remove(startVertex);

            for (int i = 0; i < countOfVertices-1; i++)
            {
                var newVertex = GetVertexWithShortestPath(_vertices);
                _vertices.Remove(newVertex);
                foreach(var currentVertex in _vertices)
                {
                    if(_distances[newVertex] + _graph.GetDistanceBetweenVertices(newVertex, currentVertex) < _distances[currentVertex])
                    {
                        _distances[currentVertex] = _distances[newVertex] + _graph.GetDistanceBetweenVertices(newVertex, currentVertex);
                    }
                }
            }

            return path;
        }

        private T GetVertexWithShortestPath(IList<T> vertices)
        {
            var minVertex = vertices.First(x => _distances[x].HasValue);
            foreach (var vertex in vertices.Where(x => _distances[x].HasValue).Skip(1))
                if (_distances[vertex] < _distances[minVertex])
                    minVertex = vertex;
            return minVertex;
        }
    }
}
