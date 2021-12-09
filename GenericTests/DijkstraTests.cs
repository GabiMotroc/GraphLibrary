using System;
using System.Collections.Generic;
using Graphs;
using Xunit;

namespace AlgorithmTests
{
    public class DijkstraTests
    {
        [Fact]
        public void MaxValueTest()
        {
            // Arrange
            const string name = "MaxValue";
            // Act
            var check = Algorithms.ReadStaticField<int>(name) == int.MaxValue;

            // Assert
            Assert.True(check, $"The max value is wrong");
        }

        [Theory]
        [MemberData(nameof(TestGraphGenerator.GetDijsktraTest), MemberType = typeof(TestGraphGenerator))]
        public void DijkstraTest(WeightedGraph<int, float> graph, int startNode, IEnumerable<Tuple<int, float>> expected)
        {
            // Arrange
            var algorithm = new Algorithms();
            // Act
            var result = algorithm.Dijkstra(graph, new Node<int>{ Id = startNode});
            var finalCondition = true;
            foreach (var (nodeId, distance) in expected)
            {
                var node = new Node<int> {Id = nodeId};
                if(result.ContainsKey(node))
                {
                    if (result[node].Equals(distance) == false)
                        finalCondition = false;
                }
                else
                {
                    finalCondition = false;
                    break;
                }
            }
            // Assert
            Assert.True(finalCondition, "Dijkstra's test failed");
        }

        [Theory]
        [InlineData(2)]
        [InlineData(2d)]
        [InlineData(2.0f)]
        [InlineData((ulong)2)]
        [InlineData((byte)2)]
        public void TestForReturnTypeToBeTheSameAsInputType<T>(T type)
        {
            var result = Algorithms.ReadStaticField<T>("MaxValue");

            Assert.IsType<T>(result);
        }
    }
}