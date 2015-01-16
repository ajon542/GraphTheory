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
        /// Perform a breadth first search to determine if a path exists between
        /// the supplied vertices.
        /// </summary>
        /// <param name="graph">The graph to query.</param>
        /// <param name="v1">The starting vertex.</param>
        /// <param name="v2">The target vertex.</param>
        /// <returns><c>true</c> if a path exists; otherwise, <c>false</c>.</returns>
        public static bool BreadthFirstPathExists(IGraph graph, int v1, int v2)
        {
            if (!graph.Contains(v1) || !graph.Contains(v2))
            {
                // Can't find a path between vertices that don't exist.
                return false;
            }

            if (v1 == v2)
            {
                // Path exists between the same vertices.
                return true;
            }

            List<int> visited = new List<int>();
            Queue<int> vertices = new Queue<int>();
            vertices.Enqueue(v1);

            while (vertices.Count > 0)
            {
                // Keep track of the current vertex.
                int current = vertices.Dequeue();

                // If we have reached the target vertex, a path exists.
                if (current == v2)
                {
                    return true;
                }

                // No need to add the vertex if we have already visited it.
                if (!visited.Contains(current))
                {
                    visited.Add(current);

                    // Add the neighbouring vertices.
                    List<int> neighbours = graph.GetNeighbours(current);
                    foreach (int vertex in neighbours)
                    {
                        // No need to add the vertex if it is already in the list to process.
                        if (!vertices.Contains(vertex))
                        {
                            vertices.Enqueue(vertex);
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Perform a depth first search to determine if a path exists between
        /// the supplied vertices.
        /// </summary>
        /// <param name="graph">The graph to query.</param>
        /// <param name="v1">The starting vertex.</param>
        /// <param name="v2">The target vertex.</param>
        /// <returns><c>true</c> if a path exists; otherwise, <c>false</c>.</returns>
        public static bool DepthFirstPathExists(IGraph graph, int v1, int v2)
        {
            if (!graph.Contains(v1) || !graph.Contains(v2))
            {
                // Can't find a path between vertices that don't exist.
                return false;
            }

            if (v1 == v2)
            {
                // Path exists between the same vertices.
                return true;
            }

            List<int> visited = new List<int>();
            Stack<int> vertices = new Stack<int>();
            vertices.Push(v1);

            while (vertices.Count > 0)
            {
                // Keep track of the current vertex.
                int current = vertices.Pop();

                // If we have reached the target vertex, a path exists.
                if (current == v2)
                {
                    return true;
                }

                // No need to add the vertex if we have already visited it.
                if (!visited.Contains(current))
                {
                    visited.Add(current);

                    // Add the neighbouring vertices.
                    List<int> neighbours = graph.GetNeighbours(current);
                    foreach (int vertex in neighbours)
                    {
                        // No need to add the vertex if it is already in the list to process.
                        if (!vertices.Contains(vertex))
                        {
                            vertices.Push(vertex);
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Find the shortest path between the given vertices.
        /// </summary>
        /// <param name="graph">The graph to query.</param>
        /// <param name="v1">The starting vertex.</param>
        /// <param name="v2">The target vertex.</param>
        /// <returns>A list of vertices in the shortest path. Null if no path exists.</returns>
        public static List<int> Dijkstra(IGraph graph, int v1, int v2)
        {
            // Contains the mapping of vertex and shortest distance from the source vertex.
            Dictionary<int, int> distance = new Dictionary<int, int>();

            // Contains the mapping of previous verticies to obtain the shortest path.
            Dictionary<int, int> previous = new Dictionary<int, int>();

            // Contains the list of unvisited vertices.
            List<int> unvisited = new List<int>();

            // Initialize the data structures.
            List<int> vertices = graph.VertexList;
            foreach (int vertex in vertices)
            {
                if (vertex != v1)
                {
                    distance[vertex] = int.MaxValue;
                    previous[vertex] = -1;
                }
                unvisited.Add(vertex);
            }
            distance[v1] = 0;

            // While there are still vertices to visit.
            while (unvisited.Count > 0)
            {
                // Find and remove the vertex with the minimum distance from source so far.
                int u = 0;
                int min = int.MaxValue;
                foreach (int vertex in unvisited)
                {
                    if (distance[vertex] <= min)
                    {
                        u = vertex;
                        min = distance[vertex];
                    }
                }
                unvisited.Remove(u);

                // For each of the neighbouring vertices, update the distance from source
                // and previous vertex. For this graph, we assume the edges all have equal weights.
                List<int> neighbours = graph.GetNeighbours(u);
                foreach (int neighbour in neighbours)
                {
                    int alt = distance[u] + 1;
                    if (alt < distance[neighbour])
                    {
                        distance[neighbour] = alt;
                        previous[neighbour] = u;
                    }
                }
            }

            // Construct the list of vertices in the shortest path.
            if (distance[v2] < 0)
            {
                // Could not find a path to the target vertex.
                return null;
            }

            // Backtrack through the previous vertex list.
            List<int> shortestPath = new List<int>();
            int currentVertex = v2;
            shortestPath.Add(currentVertex);
            while (currentVertex != v1)
            {
                currentVertex = previous[currentVertex];
                shortestPath.Add(currentVertex);
            }
            return shortestPath;
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

        public List<int> GetNeighbours(int vertex)
        {
            if (!graph.ContainsKey(vertex))
            {
                throw new ArgumentNullException("vertex");
            }

            return new List<int>(graph[vertex]);
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
