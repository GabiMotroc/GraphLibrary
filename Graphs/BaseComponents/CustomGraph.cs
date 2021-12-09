using System;
using System.Collections;
using System.Collections.Generic;

namespace Graphs
{
    public class CustomGraph<T, TNode, TEdge> : /*IEnumerable,*/ IGraph<T, TNode, TEdge>
        where TNode : INode<T>, new()
        where TEdge : IEdge<T>, new()
    {
        private IGraph<T, TNode, TEdge> _graphImplementation;
        public Dictionary<TNode, HashSet<TEdge>> AdjacencyList { get; } = new Dictionary<TNode, HashSet<TEdge>>();

        protected CustomGraph() { }

        protected CustomGraph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
        {
            foreach (var item in vertices)
                // ReSharper disable once VirtualMemberCallInConstructor
                AddVertex(item);

            foreach (var item in edges)
                // ReSharper disable once VirtualMemberCallInConstructor
                AddEdge(item);
        }

        protected virtual void AddEdge(Tuple<T, T> item)
        {
            var node = new TNode
            {
                Id = item.Item1
            };
            var edge = new TEdge
            {
                Node = item.Item2
            };

            AdjacencyList[node].Add(edge);
        }

        protected virtual void AddVertex(T nodeName)
        {
            var node = new TNode
            {
                Id = nodeName
            };

            AdjacencyList[node] = new HashSet<TEdge>();
        }

        // public IEnumerator GetEnumerator()
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // IEnumerator IEnumerable.GetEnumerator()
        // {
        //     throw new System.NotImplementedException();
        // }
    }
}