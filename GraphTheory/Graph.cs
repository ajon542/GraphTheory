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

        public void PrintPath(int v1, int v2)
        {
            if (!graph.ContainsKey(v1) || !graph.ContainsKey(v2))
            {
                // Can't find a path between vertices that don't exist.
                return;
            }

            if (v1 == v2)
            {
                // No path if vertices are the same.
                return;
            }

            Queue<int> vertices = new Queue<int>();
            vertices.Enqueue(v1);

            List<int> visited = new List<int>();

            while(vertices.Count > 0)
            {
                int current = vertices.Dequeue();
                visited.Add(current);
                if(current == v2)
                {
                    Console.WriteLine("Found Path");
                    return;
                }

                foreach(int vertex in graph[current])
                {
                    if(!visited.Contains(vertex))
                    {
                        vertices.Enqueue(vertex);
                    }
                }
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
                foreach(int vertex in edges.Value)
                {
                    sb.AppendFormat("({0}, {1}) ", edges.Key, vertex);
                }
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
