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
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);
            graph.AddEdge(3, 5);
            graph.AddEdge(4, 5);
            graph.AddEdge(4, 8);
            graph.AddEdge(5, 8);
            graph.AddEdge(3, 6);
            graph.AddEdge(5, 6);
            graph.AddEdge(5, 7);
            graph.AddEdge(7, 6);
            graph.AddEdge(7, 8);
            graph.AddEdge(7, 9);

            Console.WriteLine(graph.BreadthFirstPathExists(1, 9));

            Console.ReadLine();
        }
    }
}
