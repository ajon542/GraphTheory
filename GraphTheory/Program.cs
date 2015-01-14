using System;

namespace GraphTheory
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3);

            graph.RemoveEdge(1, 2);
            graph.RemoveEdge(1, 2);
            graph.RemoveEdge(1, 3);
            graph.RemoveEdge(2, 3);
        }
    }
}
