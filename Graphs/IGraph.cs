using System.Collections;
using System.Collections.Generic;

namespace Graphs
{
    public interface IGraph<T, TNode, TEdge> : IGraph
        where TNode : INode<T>, new()
        where TEdge : IEdge<T>, new()
    {
        Dictionary<TNode, HashSet<TEdge>> AdjacencyList { get; }

        //IEnumerator GetEnumerator();
    }

    public interface IGraph

    {

    }

}