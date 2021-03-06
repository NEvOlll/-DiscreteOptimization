﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphLibrary.Graph
{
    public class BaseGraph<T>: IGraph<T>
    {
        protected readonly Dictionary<T, Dictionary<T, float>> Relations;
        protected readonly List<Edge<T>> Edges;

        protected BaseGraph()
        {
            Relations = new Dictionary<T, Dictionary<T, float>>();
            Edges= new List<Edge<T>>();
        }

        public virtual void AddVertexWithId(T id)
        {
            Relations.Add(id, new Dictionary<T, float>());
        }

        public IEnumerable<T> GetVertices()
        {
            return Relations.Keys;
        }

        public IEnumerable<Edge<T>> GetEdges()
        {
            return Edges;
        }

        public IEnumerable<T> GetRelatedVertices(T id)
        {
            return Relations[id].Select(x => x.Key);
        }

        public bool IsContainsEdge(Edge<T> edge)
        {
            return Edges.Contains(edge);
        }

        public int GetCountOfVertices()
        {
            return Relations.Count;
        }

        public int GetCountOfEdges()
        {
            return Edges.Count;
        }

        public float? GetWeightOfEdge(T vertexId1, T vertexId2)
        {
            if (vertexId1.Equals(vertexId2))
                return 0;

            if (Relations.ContainsKey(vertexId1) && Relations[vertexId1].ContainsKey(vertexId2))
                return Relations[vertexId1][vertexId2];
            return null;
        }
    }
}
