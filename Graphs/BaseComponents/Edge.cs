using System.Collections.Generic;

namespace Graphs
{
    public class Edge<T> : IEdge<T>
    {
        public T Node { get; set; }
        public Edge(T node)
        {
            this.Node = node;
        }
        public Edge()
        {

        }
    }
}