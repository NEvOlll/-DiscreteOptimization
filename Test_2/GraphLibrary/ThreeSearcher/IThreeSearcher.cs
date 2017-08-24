using GraphLibrary.Graph;

namespace GraphLibrary.ThreeSearcher
{
    public interface IThreeSearcher<T>
    {
        IGraph<T> GetThreeFromVertex(T startVertexId);
    }
}
