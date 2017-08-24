namespace GraphLibrary.Graph
{
    interface ISimpleGraph<T>: IGraph<T>
    {
        void AddEdgeBetweenVertices(T id1, T id2, float weight = 0);
        void AddEdgeWithVertices(T id1, T id2, float weight = 0);
        void AddEdgeWithVertices(Edge<T> edge);
    }
}
