using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary.Graph;

namespace GraphLibrary
{
    public class BreadthFirstSearch<T>
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

        private void StartWith(T vertexId)
        {
            var vertexQueue = new Queue<T>();
            vertexQueue.Enqueue(vertexId);                     

            while (vertexQueue.Any())
            {                             
                var currentVertex = vertexQueue.Dequeue();
                _marker++;
                _markedVertices[currentVertex] = _marker;

                foreach (var relatedVertex in _graph.GetRelatedVertices(currentVertex))
                {
                    if (_markedVertices[relatedVertex] == 0)
                    {
                        vertexQueue.Enqueue(relatedVertex);
                        _path[relatedVertex] = currentVertex;
                    }
                }                
            }
        }

        public Dictionary<T, T> GetBThree(T vertexId)
        {
            StartWith(vertexId);
            return _path;
        }
    }
}
