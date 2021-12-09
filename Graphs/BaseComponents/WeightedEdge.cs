using System;

namespace Graphs
{
    public class WeightedEdge<T, TWeight> : IWeightedEdge<T, TWeight>
        where TWeight : struct, IComparable<TWeight>
    {

        public T Node { get; set; }
        public TWeight Weight { get; set; }
        public WeightedEdge(T node, TWeight weight)
        {
            this.Node = node;
            this.Weight = weight;
        }
        public WeightedEdge()
        {

        }
        
        public TWeight Add(TWeight number)
        {
            dynamic a = number;
            dynamic b = Weight;
            return a + b;
        }
    }
}