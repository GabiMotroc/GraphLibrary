using System;
using System.Collections;
using System.Collections.Generic;
using Graphs;
using Xunit;

namespace AlgorithmTests
{
    public class KruskalTests
    {
        [Theory]
        [MemberData(nameof(TestGraphGenerator.GetWeightedGraph), MemberType = typeof(TestGraphGenerator))]
        public void KruskalTest(WeightedGraph<int, float> graph, WeightedGraph<int, float> expected)
        
        {
            //Given
            var algorithm = new Algorithms();
            //When

            var result = algorithm.Kruskal(graph);
            //Then
            
            Assert.True(expected.Equals(result));
        }
    }
}