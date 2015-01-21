using System;
using System.Collections.Generic;
using System.Text;

namespace GraphTheory
{
    class SimpleGraph : IGraph
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
        /// Determines if the given vertex exists in the graph.
        /// </summary>
        /// <param name="vertex">The vertex.</param>
        /// <returns><c>true</c> if the graph contains the given vertex; otherwise, <c>false</c>.</returns>
        public bool Contains(int vertex)
        {
            return graph.ContainsKey(vertex);
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

        /// <summary>
        /// Gets a list of the vertices in this graph.
        /// </summary>
        public List<int> VertexList
        {
            get { return new List<int>(graph.Keys); }
        }

        /// <summary>
        /// Get the neighbouring vertices.
        /// </summary>
        /// <param name="vertex">The vertex.</param>
        /// <returns>A list of the neighbouring vertices.</returns>
        public List<int> GetNeighbours(int vertex)
        {
            if (!graph.ContainsKey(vertex))
            {
                throw new ArgumentNullException("vertex");
            }

            return new List<int>(graph[vertex]);
        }

        /// <summary>
        /// Gets the number of edges incident to this vertex.
        /// </summary>
        /// <param name="vertex">The vertex.</param>
        /// <returns>The number of edges incident to this vertex.</returns>
        public int GetDegree(int vertex)
        {
            if (!graph.ContainsKey(vertex))
            {
                throw new ArgumentNullException("vertex");
            }

            return graph[vertex].Count;
        }

        /// <summary>
        /// String representation of the graph.
        /// </summary>
        /// <returns>A string representation of the graph.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");
            foreach (KeyValuePair<int, List<int>> edges in graph)
            {
                foreach (int vertex in edges.Value)
                {
                    sb.AppendFormat("({0}, {1}) ", edges.Key, vertex);
                }
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
