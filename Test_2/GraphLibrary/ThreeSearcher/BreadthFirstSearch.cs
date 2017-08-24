using System;
using System.Collections.Generic;
using System.Linq;
using GraphLibrary.Graph;

namespace GraphLibrary.ThreeSearcher
{
    public class BreadthFirstSearch<T> : IThreeSearcher<T>
    {
        private readonly IGraph<T> _graph;
        private readonly Dictionary<T, int> _markedVertices;
        private int _marker;
        private readonly Dictionary<T, T> _path;

        public BreadthFirstSearch(IGraph<T> graph)
        {
            if (graph == null)
                throw new ArgumentNullException("graph");
            _graph = graph;
            _markedVertices = _graph.GetVertices().ToDictionary(vertex => vertex, value => 0);
            _marker = 0;
            _path = new Dictionary<T, T>();       
        }

        private void StartWith(T startVertexId)
        {
            //Tuple - Item1 - from, Item2 - to
            var vertexQueue = new Queue<Tuple<T,T>>();            
            _markedVertices[startVertexId] = ++_marker;
            foreach (var relatedVertex in _graph.GetRelatedVertices(startVertexId))
                vertexQueue.Enqueue(new Tuple<T, T>(startVertexId, relatedVertex));
            while (vertexQueue.Any())
            {                             
                var currentPair = vertexQueue.Dequeue();
                if (_markedVertices[currentPair.Item2] != 0)
                    continue;
                _markedVertices[currentPair.Item2] = ++_marker;
                _path.Add(currentPair.Item2, currentPair.Item1);
                foreach (var relatedVertex in _graph.GetRelatedVertices(currentPair.Item2))                
                    if (_markedVertices[relatedVertex] == 0)                    
                        vertexQueue.Enqueue(new Tuple<T,T>(currentPair.Item2, relatedVertex));                                                            
            }
        }

        public IGraph<T> GetThreeFromVertex(T vertexId)
        {
            StartWith(vertexId);
            var three = new SimpleGraph<T>();
            foreach (var edge in _path)
                three.AddEdgeWithVertices(edge.Key, edge.Value);
            return three;
        }
    }
}
