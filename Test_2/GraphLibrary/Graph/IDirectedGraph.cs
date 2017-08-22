namespace GraphLibrary.Graph
{
    interface IDirectedGraph<T>: IGraph<T>
    {
        void AddEdgeBetweenVerticesFromV1ToV2(T id1, T id2, int weight = 0);
        void AddEdgeWithVerticesFromV1ToV2(T id1, T id2, int weight = 0);
        void AddEdgeWithVerticesFromV1ToV2(Edge<T> edge);
    }
}
