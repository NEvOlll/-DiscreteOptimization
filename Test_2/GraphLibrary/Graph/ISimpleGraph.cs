using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Graph
{
    interface ISimpleGraph<T>: IGraph<T>
    {
        void AddEdgeBetweenVertices(T id1, T id2, int weight = 0);
        void AddEdgeWithVertices(T id1, T id2, int weight = 0);
        void AddEdgeWithVertices(Edge<T> edge);
    }
}
