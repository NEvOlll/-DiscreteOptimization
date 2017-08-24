using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary.Graph;

namespace GraphLibrary.ShortestPathSearcher
{
    /// <summary>
    /// Применим в случае безконтурной сети
    /// </summary>
    public class ShortsetPathSearcher<T>: IShortestPathSearcher<T>
    {
        private readonly IDirectedGraph<T> _graph;

        public ShortsetPathSearcher(IDirectedGraph<T> graph)
        {
            if (graph == null)
                throw new ArgumentNullException("graph");
            _graph = graph;
        }

        public Dictionary<T, T> GetShortestPathBetween(T vertexId1, T vertexId2)
        {
            throw new NotImplementedException();
        }
    }
}
