using System;

namespace Graphs
{
    public interface IWeightedGraph
    {
        
    }

    public interface IWeightedGraph<T, TNode, TEdge, TWeight> : IGraph<T, TNode, TEdge>, IWeightedGraph
        where TNode : INode<T>, new()
        where TEdge : IWeightedEdge<T, TWeight>, new()
        where TWeight : struct, IComparable<TWeight>
    {

    }
}