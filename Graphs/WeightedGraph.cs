using System;
using System.Collections;
using System.Collections.Generic;

namespace Graphs
{
    public class WeightedGraph<T, TWeight> : CustomGraph<T, Node<T>, WeightedEdge<T, TWeight>>, IWeightedGraph<T, Node<T>, WeightedEdge<T, TWeight>, TWeight>
        where TWeight : struct, IComparable<TWeight>
    {
        public WeightedGraph()
        {

        }
        public WeightedGraph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T, TWeight>> edges)
        {
            foreach (var item in vertices)
                AddVertex(item);

            foreach (var item in edges)
                AddEdge(item);
        }

        private void AddEdge(Tuple<T, T, TWeight> item)
        {
            var (startNode, endNode, weight) = item;
            var node = new Node<T>
            {
                Id = startNode
            };

            var edge = new WeightedEdge<T, TWeight>
            {
                Node = endNode,
                Weight = weight
            };
            
            AdjacencyList[node].Add(edge);
        }
    }
}