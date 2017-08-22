using System.Collections.Generic;

namespace GraphLibrary.ShortestPathSearcher
{
    public interface IShortestPathSearcher<T>
    {
        Dictionary<T, T> GetShortestPathBetween(T vertexId1, T vertexId2);
    }
}
