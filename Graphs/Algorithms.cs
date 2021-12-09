using System;
using System.Collections.Generic;
using System.Reflection;

namespace Graphs
{
    public class Algorithms
    {
        public HashSet<TNode> DFS<T, TNode, TEdge>(IGraph<T, TNode, TEdge> graph, TNode start)
            where TNode : INode<T>, new()
            where TEdge : IEdge<T>, new()
        {
            var visited = new HashSet<TNode>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var stack = new Stack<TNode>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in graph.AdjacencyList[vertex])
                {
                    var currentNode = new TNode();
                    currentNode.Id = neighbor.Node;
                    if (!visited.Contains(currentNode))
                        stack.Push(currentNode);
                }
            }

            return visited;
        }

        public HashSet<TNode> BFS<T, TNode, TEdge>(IGraph<T, TNode, TEdge> graph, TNode start)
            where TNode : INode<T>, new()
            where TEdge : IEdge<T>, new()
        {
            var visited = new HashSet<TNode>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var queue = new Queue<TNode>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in graph.AdjacencyList[vertex])
                {
                    var currentNode = new TNode
                    {
                        Id = neighbor.Node
                    };
                    if (!visited.Contains(currentNode))
                        queue.Enqueue(currentNode);
                }
            }

            return visited;
        }

        public Dictionary<TNode, TWeight> Dijkstra<T, TNode, TEdge, TWeight>(IWeightedGraph<T, TNode, TEdge, TWeight> graph, TNode start)
            where TNode : INode<T>, new()
            where TEdge : IWeightedEdge<T, TWeight>, new()
            where TWeight : struct, IComparable<TWeight>
        {
            if (graph.AdjacencyList.ContainsKey(start) == false)
                throw new ArgumentException($"The start, {start.Id} node is not part of the graph.");
            
            var distance = new Dictionary<TNode, TWeight>();
            var queue = new Queue<TNode>();
            var visited = new HashSet<TNode>();
            
            queue.Enqueue(start);

            var maxValue = ReadStaticField<TWeight>("MaxValue");

            foreach (var vertex in graph.AdjacencyList.Keys)
            {
                // queue.Enqueue(vertex);
                distance[vertex] = maxValue;
            }
            
            distance[start] = default(TWeight);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                visited.Add(currentNode);

                foreach (var neighbor in graph.AdjacencyList[currentNode])
                {
                    var nextNode = GetTheNodeConnectedByEdge(neighbor);
                    if(!visited.Contains(currentNode))
                        queue.Enqueue(nextNode);

                    UpdateDistanceIfSmaller(distance, currentNode, neighbor, nextNode);
                }
            }

            return distance;

            void UpdateDistanceIfSmaller(IDictionary<TNode, TWeight> nodes, TNode currentNode, TEdge neighbor, TNode nextNode)
            {
                if (neighbor.Add(nodes[currentNode]).CompareTo(nodes[nextNode]) < 0)
                    nodes[nextNode] = neighbor.Add(nodes[currentNode]);
            }

            TNode GetTheNodeConnectedByEdge(TEdge neighbor)
            {
                var nextNode = new TNode
                {
                    Id = neighbor.Node
                };
                return nextNode;
            }
        }

        public IWeightedGraph<T, TNode, TEdge, TWeight> Kruskal<T, TNode, TEdge, TWeight>(IWeightedGraph<T, TNode, TEdge, TWeight> graph)
            where TNode : INode<T>, new()
            where TEdge : IWeightedEdge<T, TWeight>, new()
            where TWeight : struct, IComparable<TWeight>
        {
            var mst = graph ?? throw new ArgumentNullException(nameof(graph));
            
            return mst;
        }
        public static TWeight ReadStaticField<TWeight>(string name)
        {
            FieldInfo field = typeof(TWeight).GetField(name,
                BindingFlags.Public | BindingFlags.Static);
            if (field == null)
            {
                // There's no TypeArgumentException, unfortunately. You might want
                // to create one :)
                throw new InvalidOperationException
                    ("Invalid type argument for NumericUpDown<T>: " +
                     typeof(TWeight).Name);
            }
            return (TWeight)field.GetValue(null);
        }

    }
}