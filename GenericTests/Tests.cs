using System;
using Xunit;
using Graphs;

namespace AlgorithmTests
{
    public class Tests
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }
    }
    
    public class GenericTests
    {
        [Fact]
        public void MaxValueTest()
        {
            // Arrange
            var intTest = new Algorithms();
            
            // Act
            var maxValueInt = Algorithms.ReadStaticField<int>("MaxValue");

            // Assert
            Assert.True(maxValueInt == int.MaxValue, $"The max value is wrong");
        }

        [Fact]
        public void Test()
        {
            const bool a = true;
            Assert.True(a);
        }
    }
}