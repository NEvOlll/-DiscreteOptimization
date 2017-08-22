using System;
using System.Collections.Generic;
using System.Linq;
using GraphLibrary.Graph;

namespace GraphLibrary
{
    public class MinimumSpanningTreeSearch<T>
    {
        private readonly IGraph<T> _graph;
        private readonly List<Edge<T>> _edges;

        public MinimumSpanningTreeSearch(IGraph<T> graph)
        {
            if(graph == null)
                throw new ArgumentNullException("graph");
            _graph = graph;
            _edges = _graph.GetEdges().ToList();
        }

        public IGraph<T> GetMinimumSpanningTree()
        {
            //сортируем ребра по возрастанию
            var sortedEdges = new Queue<Edge<T>>(_edges.OrderBy(x => x.Weight));
            //из ребер достаем все вершины
            var vertices = new HashSet<T>();
            foreach (var endge in _edges)
            {
                vertices.Add(endge.Vertex1);
                vertices.Add(endge.Vertex2);
            }
            var countOfVertices = vertices.Count;
            var three = new SimpleGraph<T>();

            //создаем лес состоящий из вершин (каждая вершина - отдельная компонента связности)
            var verticesCmponentsDictionary = vertices.ToDictionary(x => x, x => x);
            //создаем словарь компонент связностей со списком вершин
            var connectedComponents = vertices.ToDictionary(x => x, x => new List<T> { x });

            while (three.GetCountOfEdges() < countOfVertices - 1)
            {
                var edge = sortedEdges.Dequeue();
                
                var componen1Id = verticesCmponentsDictionary[edge.Vertex1];
                var componen2Id = verticesCmponentsDictionary[edge.Vertex2];
                //проверяем что вершины ребра не находятся уже в одной компоненте связности
                if (!componen1Id.Equals(componen2Id))
                {
                    //сравниваем количество вершин в каждой из компонент связности
                    if (connectedComponents[componen1Id].Count > connectedComponents[componen2Id].Count)
                    {
                        foreach (var vertex in connectedComponents[componen2Id])
                        {
                            verticesCmponentsDictionary[vertex] = componen1Id;
                            connectedComponents[componen1Id].Add(vertex);
                        }
                        connectedComponents.Remove(componen2Id);
                    }
                    else
                    {
                        foreach (var vertex in connectedComponents[componen1Id])
                        {
                            verticesCmponentsDictionary[vertex] = componen2Id;
                            connectedComponents[componen2Id].Add(vertex);
                        }
                        connectedComponents.Remove(componen1Id);
                    }

                    three.AddEdgeWithVertices(edge);
                }
            }

            return three;
        }
    }
}
