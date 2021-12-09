using System;

namespace Graphs
{
    public interface IWeightedEdge<T, TWeight> : IEdge<T>
        where TWeight : struct, IComparable<TWeight>
    {
        TWeight Weight { get; set;}

        TWeight Add(TWeight number);
    }
}