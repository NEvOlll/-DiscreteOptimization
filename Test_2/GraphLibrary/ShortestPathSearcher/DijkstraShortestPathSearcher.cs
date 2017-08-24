using System;
using System.Collections.Generic;
using System.Linq;
using GraphLibrary.Graph;

namespace GraphLibrary.ShortestPathSearcher
{
    /// <summary>
    /// Применим в случае неотрицательных весов
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DijkstraShortestPathSearcher<T> : IShortestPathSearcher<T>
    {
        private readonly IGraph<T> _graph;
        private readonly IList<T> _vertices;
        private IDictionary<T, float?> _distances;
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
            _distances = _vertices.ToDictionary(v => v, v => _graph.GetWeightOfEdge(startVertex, v));
            var path = _distances
                .Where(x => x.Value.HasValue)
                .ToDictionary(v => v.Key, v => startVertex);
            _vertices.Remove(startVertex);

            for (int i = 0; i < countOfVertices-1; i++)
            {
                var chosenVertex = GetVertexWithShortestPath(_vertices);
                _vertices.Remove(chosenVertex);
                foreach(var currentVertex in _vertices)
                {
                    var dist = _graph.GetWeightOfEdge(chosenVertex, currentVertex);
                    //если в текущую вершину нельзя попасть из выбранной, то переходим к следующей
                    if (!dist.HasValue)
                        continue;
                    
                    if(!_distances[currentVertex].HasValue 
                        || (_distances[chosenVertex] + dist.Value)< _distances[currentVertex])
                    {
                        _distances[currentVertex] = _distances[chosenVertex] + dist.Value;
                        path[currentVertex] = chosenVertex;
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
