using System;
using System.Collections.Generic;
using System.Linq;
using GraphLibrary.Graph;

namespace GraphLibrary
{
    public class EulerianPathSearcher<T>
    {
        private readonly Dictionary<T, List<T>> _relations;
        
        public EulerianPathSearcher(IGraph<T> graph)
        {
            if (graph == null)
                throw new ArgumentNullException("graph");            
            _relations = new Dictionary<T, List<T>>();
            foreach (var vetex in graph.GetVertices())
            {
                var relatedVertices = new List<T>(graph.GetRelatedVertices(vetex));
                if (relatedVertices.Count % 2 == 1)
                    throw new ArgumentException(
                        string.Format("Данный граф не является Эйлеровым, т.к. у вершины {0}, нечетная степень", vetex));
                _relations.Add(vetex, relatedVertices);                
            }  
        }

        public IEnumerable<T> GetPath()
        {
            var pathStack = new Stack<T>();
            var firstVertex = _relations.Keys.First();
            var workStack = new Stack<T>();
            workStack.Push(firstVertex);
            while (workStack.Any())
            {
                var currentVertex = workStack.Peek();
                if (_relations[currentVertex].Any())
                {
                    var nextVertex = _relations[currentVertex].First();
                    _relations[currentVertex].Remove(nextVertex);
                    _relations[nextVertex].Remove(currentVertex);
                    workStack.Push(nextVertex);
                }
                else
                {
                    var pathVertex = workStack.Pop();
                    pathStack.Push(pathVertex);
                }
            }

            return pathStack;
        }
    }
}
