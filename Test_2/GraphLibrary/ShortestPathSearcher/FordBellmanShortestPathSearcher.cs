using System;
using System.Collections.Generic;
using System.Linq;
using GraphLibrary.Graph;

namespace GraphLibrary.ShortestPathSearcher
{
    /// <summary>
    /// Подходит для сетей не содержащит отрицательные контуры (контуры, сумма всеов которых < 0)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FordBellmanShortestPathSearcher<T> : IShortestPathSearcher<T>
    {
        private readonly IGraph<T> _graph;
        //важно что бы граф не содержал отрицательных контуров (контуров сумма ребер которых < 0)
        public FordBellmanShortestPathSearcher(IGraph<T> graph)
        {
            if (graph == null)
                throw new ArgumentNullException("graph");
            _graph = graph;
        }

        public Dictionary<T, T> GetShortestPathBetween(T vertexId1, T vertexId2)
        {
            var startVertex = vertexId1;
            var countOfVertices = _graph.GetCountOfVertices();
            var vertices = _graph.GetVertices().ToList();
            var distances = vertices.ToDictionary(v => v, v => _graph.GetWeightOfEdge(startVertex, v));

            var path = distances
                .Where(x => x.Value.HasValue)
                .ToDictionary(v => v.Key, v => startVertex);

            for (int i = 0; i < countOfVertices-2; i++)
            {
                foreach (var updatingVertex in vertices)
                {
                    //обновлять расстояние от начальной вершины нет смысла, оно всегда равно 0
                    if (updatingVertex.Equals(startVertex))
                        continue;
                    foreach (var currentVertex in vertices)
                    {
                        //если от текущей вершины до начальной нет пути, то считать расстояние от текущей вершины до обновляемой нет смысла
                        if (!distances[currentVertex].HasValue)
                            continue;
                        //если от обвноляемой вершины до текущей нет ребра, то и новый путь мы не сможем посчитать
                        var dist = _graph.GetWeightOfEdge(currentVertex, updatingVertex);
                        if(!dist.HasValue)
                            continue;
                        //если у обновляемой вершины нет пути от стартовой или новый путь короче, то мы обновляем путь
                        if (!distances[updatingVertex].HasValue
                            || (distances[currentVertex] + dist) < distances[updatingVertex])
                        {
                            distances[updatingVertex] = distances[currentVertex] + dist;
                            path[updatingVertex] = currentVertex;
                        }
                    }                
                }
            }

            if (!distances[vertexId2].HasValue)
                return null;
            return path;
        }
    }
}
