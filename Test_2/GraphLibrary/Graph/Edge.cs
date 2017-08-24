using System.Security.Cryptography;

namespace GraphLibrary.Graph
{
    public class Edge<T>
    {
        //для ориентированного графа ребро направлено от Vertex1 к Vertex2
        public T Vertex1 { get; set; }
        public T Vertex2 { get; set; }
        public float Weight { get; set; }

        public Edge(T vertex1, T vertex2, float weigth = 0)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
            Weight = weigth;
        }

        /// <summary>
        /// Метод выполняет проверку равенства ребер только для случая неориентированного ребра
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var edge = obj as Edge<T>;
            if (edge == null)
                return base.Equals(obj);

            if(this.Vertex1.Equals(edge.Vertex1) && this.Vertex2.Equals(edge.Vertex2) && this.Weight == edge.Weight)
                return true;
            if (this.Vertex1.Equals(edge.Vertex2) && this.Vertex2.Equals(edge.Vertex1) && this.Weight == edge.Weight)
                return true;

            return false;
        }
    }
}
