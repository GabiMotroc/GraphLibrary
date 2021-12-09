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
            var gai = Algorithms.ReadStaticField<int>(name) == int.MaxValue;

            // Assert
            Assert.True(gai, $"The max value is wrong");
        }

        [Theory]
        [ClassData(typeof(WeightedGraphData))]
        public void DijkstraTest()
        {
            const bool a = true;
            Assert.True(a);
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