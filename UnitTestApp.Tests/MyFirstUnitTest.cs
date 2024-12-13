using System;
using Xunit;

namespace UnitTestApp.Tests
{
    public class MyFirstUnitTest
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
            Assert.Equal(9, Add(3, 3));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        public void IsOdd_MyFirstTheory(int value)
        {
            Assert.True(IsOdd(value));
        }

        bool IsOdd(int value) => value % 2 == 1;    // проверка на четность
        int Add(int x, int y) => x * y;             // умножение
    }

}
