using System;
using System.Collections.Generic;
using System.Text;

namespace GraphTheory
{
    class Graph
    {
        /// <summary>
        /// A simple graph data structure.
        /// </summary>
        private Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        /// <summary>
        /// Adds an edge (pair of vertices) to the graph.
        /// </summary>
        /// <param name="v1">The first vertex.</param>
        /// <param name="v2">The second vertex.</param>
        public void AddEdge(int v1, int v2)
        {
            if (graph.ContainsKey(v1) && graph[v1].Contains(v2))
            {
                // Edge between v1 and v2 already exists.
                return;
            }

            // Add edge between v1 and v2.
            if (graph.ContainsKey(v1))
            {
                graph[v1].Add(v2);
            }
            else
            {
                graph[v1] = new List<int>();
                graph[v1].Add(v2);
            }

            // Add edge between v2 and v1.
            if (graph.ContainsKey(v2))
            {
                graph[v2].Add(v1);
            }
            else
            {
                graph[v2] = new List<int>();
                graph[v2].Add(v1);
            }
        }

        /// <summary>
        /// Removes an edge (pair of vertices) from the graph.
        /// </summary>
        /// <param name="v1">The first vertex.</param>
        /// <param name="v2">The second vertex.</param>
        public void RemoveEdge(int v1, int v2)
        {
            if (!graph.ContainsKey(v1))
            {
                // Since this is not a directed graph, we can make this assumption.
                return;
            }

            // Remove the vertex from the list.
            graph[v1].Remove(v2);
            graph[v2].Remove(v1);

            // If the degree of this vertex is 0 i.e. there are no incident edges.
            if (graph[v1].Count == 0)
            {
                // Null the vertex list and remove the mapping.
                graph[v1] = null;
                graph.Remove(v1);
            }

            // If the degree of this vertex is 0 i.e. there are no incident edges.
            if (graph[v2].Count == 0)
            {
                // Null the vertex list and remove the mapping.
                graph[v2] = null;
                graph.Remove(v2);
            }
        }

        /// <summary>
        /// Gets the number of vertices in this graph.
        /// </summary>
        public int VertexCount
        {
            get { return graph.Count; }
        }

        /// <summary>
        /// Gets the number of edges in this graph.
        /// </summary>
        /// <remarks>
        /// In any graph, the sum of the degrees of all vertices
        /// is equal to twice the number of edges.
        /// </remarks>
        public int EdgeCount
        {
            get
            {
                int edgeCount = 0;
                foreach (KeyValuePair<int, List<int>> edges in graph)
                {
                    edgeCount += edges.Value.Count;
                }
                return edgeCount / 2;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            return sb.ToString();
        }
    }
}
