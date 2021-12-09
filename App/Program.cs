using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Graphs;
using Newtonsoft.Json;

namespace App
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var graph = GetExampleGraph();

            var algorithms = new Algorithms();
            
            System.Console.WriteLine("BFS results");
            var result = algorithms.BFS(graph, new Node<int>(10));
            foreach (var item in result)
            {
                System.Console.WriteLine(item.Id);
            }

            var weightedGraph = GetWeightedGraphExample();
            System.Console.WriteLine("DFS results");
            result = algorithms.DFS(weightedGraph, new Node<int>(1));
            foreach (var item in result)
            {
                System.Console.WriteLine(item.Id);
            }

            var json = JsonConvert.SerializeObject(weightedGraph.AdjacencyList ,Formatting.Indented);
            Console.WriteLine(json);
            System.IO.File.WriteAllText(@"C:\Users\abi\Desktop\graph.txt", json);
            
            System.Console.WriteLine("Dijkstra results");
            var result1 = algorithms.Dijkstra(weightedGraph, new Node<int>(1));
            foreach (var (node, value) in result1)
            {
                System.Console.WriteLine(node.Id);
                System.Console.WriteLine(value);
            }
        }

        private static WeightedGraph<int, float> GetWeightedGraphExample()
        {
            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var weightedEdges = new[]{Tuple.Create(1,2,12f), Tuple.Create(1,3,20f),
                Tuple.Create(2,4,3f), Tuple.Create(3,5,9f), Tuple.Create(3,6,2f),
                Tuple.Create(4,7,4f), Tuple.Create(7,5,2f), Tuple.Create(5,8,6f),
                Tuple.Create(5,6,4f), Tuple.Create(8,9,1f), Tuple.Create(8,10,7f),
                Tuple.Create(9,10,30f)};

            var graph = new WeightedGraph<int, float>(vertices, weightedEdges);
            return graph;
        }

        private static OrientedGraph<int> GetExampleGraph()
        {
            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var edges = new[]{Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(8,10),
                Tuple.Create(9,10)};

            var graph = new OrientedGraph<int>(vertices, edges);
            return graph;
        }
    }
}
