using System;
using System.Collections.Generic;

namespace Graphs
{
    public class Node<T> : INode<T>
    {
        public T Id { get; set; }
        public Node(T id)
        {
            this.Id = id;
        }
        public Node()
        {
            
        }

        public override bool Equals(object obj)
        {
            return obj is Node<T> node &&
                   EqualityComparer<T>.Default.Equals(Id, node.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}