using System.Collections.Generic;

namespace GraphTheory
{
    interface IGraph
    {
        List<int> VertexList { get; }
        int EdgeCount { get; }
        int VertexCount { get; }

        void AddEdge(int v1, int v2);
        void RemoveEdge(int v1, int v2);
        bool Contains(int vertex);
        List<int> GetNeighbours(int vertex);
    }
}
