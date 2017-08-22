namespace GraphLibrary.Graph
{
    public class Edge<T>
    {
        //для ориентированного графа ребро направлено от Vertex1 к Vertex2
        public T Vertex1 { get; set; }
        public T Vertex2 { get; set; }
        public int Weight { get; set; }

        public Edge(T vertex1, T vertex2, int weigth)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
            Weight = weigth;
        }
    }
}
