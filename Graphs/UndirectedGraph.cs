using System;
using System.Collections.Generic;

namespace Graphs
{
    public class UndirectedGraph <T, TNode, TEdge> : CustomGraph<T, TNode, TEdge>
        where TNode : INode<T>, new()
        where TEdge : IEdge<T>, new()
    {
        public UndirectedGraph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges) : base(vertices, edges)
        {
            
        }
        protected override void AddEdge(Tuple<T, T> item)
        {
            var (startNode, endNode) = item;
            
            var node = new TNode
            {
                Id = startNode
            };
            var edge = new TEdge
            {
                Node = endNode
            };

            AdjacencyList[node].Add(edge);

            var node1 = new TNode
            {
                Id = endNode
            };
            var edge1 = new TEdge
            {
                Node = startNode
            };
            AdjacencyList[node1].Add(edge1);

        }
    }
}