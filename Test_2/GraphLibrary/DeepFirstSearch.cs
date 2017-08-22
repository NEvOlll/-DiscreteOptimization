using System;
using System.Collections.Generic;
using System.Linq;
using GraphLibrary.Graph;

namespace GraphLibrary
{
    public class DeepFirstSearch<T>
    {
        private readonly IGraph<T> _graph;
        private readonly Dictionary<T, int> _markedVertices;
        private int _marker;
        private readonly Dictionary<T, T> _path;

        public DeepFirstSearch(IGraph<T> graph)
        {
            if(graph == null)
                throw new ArgumentNullException("graph");
            _graph = graph;
            _markedVertices = _graph.GetVertices().ToDictionary(vertex => vertex, value => 0);
            _marker = 0;
            _path = new Dictionary<T, T>();
        }

        private void StartWith(T vertexId)
        {            
            _marker++;
            _markedVertices[vertexId] = _marker;
            foreach (var relatedVertex in _graph.GetRelatedVertices(vertexId))
            {
                if (_markedVertices[relatedVertex] == 0)
                {
                    _path.Add(relatedVertex, vertexId);
                    StartWith(relatedVertex);
                }
            }                                            
        }

        public Dictionary<T, T> GetDThree(T vertexId)
        {
            StartWith(vertexId);
            return _path;
        }
    }
}
