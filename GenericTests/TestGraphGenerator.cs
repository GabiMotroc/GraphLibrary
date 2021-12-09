using System;
using System.Collections.Generic;
using Graphs;

namespace AlgorithmTests
{
    public class TestGraphGenerator 
    {
        public static IEnumerable<object[]> GetDijsktraTest()
        {
            yield return new object[]
            {
                new WeightedGraph<int, float>(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
                    , new[]
                    {
                        Tuple.Create(1, 2, 12f), Tuple.Create(1, 3, 20f),
                        Tuple.Create(2, 4, 3f), Tuple.Create(3, 5, 9f), Tuple.Create(3, 6, 2f),
                        Tuple.Create(4, 7, 4f), Tuple.Create(7, 5, 2f), Tuple.Create(5, 8, 6f),
                        Tuple.Create(5, 6, 4f), Tuple.Create(8, 9, 1f), Tuple.Create(8, 10, 7f),
                        Tuple.Create(9, 10, 30f)
                    }),
                1,
                new []
                {
                    Tuple.Create(1, 0f), Tuple.Create(2, 12f), 
                    Tuple.Create(3, 20f), Tuple.Create(4, 1f), 
                    Tuple.Create(5, 29f), Tuple.Create(6, 22f), 
                    Tuple.Create(7, 19f), Tuple.Create(8, 35f), 
                    Tuple.Create(9, 36f), Tuple.Create(10, 42f)
                }
            };
        }
        public static IEnumerable<object[]> GetKruskalTest()
        {
            yield return new object[]
            {
                GetWeightedGraphData(),
                new WeightedGraph<int, float>(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
                    , new[]
                    {
                        Tuple.Create(1, 2, 12f), Tuple.Create(1, 3, 20f),
                        Tuple.Create(2, 4, 3f), Tuple.Create(3, 5, 9f), Tuple.Create(3, 6, 2f),
                        Tuple.Create(4, 7, 4f), Tuple.Create(7, 5, 2f), Tuple.Create(5, 8, 6f),
                        Tuple.Create(5, 6, 4f), Tuple.Create(8, 9, 1f), Tuple.Create(8, 10, 7f),
                        Tuple.Create(9, 10, 30f), Tuple.Create(2, 1, 12f), Tuple.Create(3, 1, 20f),
                        Tuple.Create(4, 2, 3f), Tuple.Create(5, 3, 9f), Tuple.Create(6, 3, 2f),
                        Tuple.Create(7, 4, 4f), Tuple.Create(5, 7, 2f), Tuple.Create(8, 5, 6f),
                        Tuple.Create(6, 5, 4f), Tuple.Create(9, 8, 1f), Tuple.Create(10, 8, 7f),
                        Tuple.Create(10, 9, 30f)
                    })
                    
            };
        }
        public static IEnumerable<object[]> GetWeightedGraph()
        {
            yield return new object[]
            {
                new WeightedGraph<int, float>(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
                    , new[]
                    {
                        Tuple.Create(1, 2, 12f), Tuple.Create(1, 3, 20f),
                        Tuple.Create(2, 4, 3f), Tuple.Create(3, 5, 9f), Tuple.Create(3, 6, 2f),
                        Tuple.Create(4, 7, 4f), Tuple.Create(7, 5, 2f), Tuple.Create(5, 8, 6f),
                        Tuple.Create(5, 6, 4f), Tuple.Create(8, 9, 1f), Tuple.Create(8, 10, 7f),
                        Tuple.Create(9, 10, 30f), Tuple.Create(2, 1, 12f), Tuple.Create(3, 1, 20f),
                        Tuple.Create(4, 2, 3f), Tuple.Create(5, 3, 9f), Tuple.Create(6, 3, 2f),
                        Tuple.Create(7, 4, 4f), Tuple.Create(5, 7, 2f), Tuple.Create(8, 5, 6f),
                        Tuple.Create(6, 5, 4f), Tuple.Create(9, 8, 1f), Tuple.Create(10, 8, 7f),
                        Tuple.Create(10, 9, 30f)
                    })
            };
        }
        private static WeightedGraph<int, float> GetWeightedGraphData()
        {
            return new WeightedGraph<int, float>(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
                , new[]
                {
                    Tuple.Create(1, 2, 12f), Tuple.Create(1, 3, 20f),
                    Tuple.Create(2, 4, 3f), Tuple.Create(3, 5, 9f), Tuple.Create(3, 6, 2f),
                    Tuple.Create(4, 7, 4f), Tuple.Create(7, 5, 2f), Tuple.Create(5, 8, 6f),
                    Tuple.Create(5, 6, 4f), Tuple.Create(8, 9, 1f), Tuple.Create(8, 10, 7f),
                    Tuple.Create(9, 10, 30f), Tuple.Create(2, 1, 12f), Tuple.Create(3, 1, 20f),
                    Tuple.Create(4, 2, 3f), Tuple.Create(5, 3, 9f), Tuple.Create(6, 3, 2f),
                    Tuple.Create(7, 4, 4f), Tuple.Create(5, 7, 2f), Tuple.Create(8, 5, 6f),
                    Tuple.Create(6, 5, 4f), Tuple.Create(9, 8, 1f), Tuple.Create(10, 8, 7f),
                    Tuple.Create(10, 9, 30f)
                });
        }
    }
}