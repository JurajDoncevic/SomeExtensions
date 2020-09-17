using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SomeExtensions.Functional.Tests
{
    public class MappingTests
    {
        [Fact]
        public void TestMapFunction()
        {
            int anInteger = 3;
            List<int> listOfInts = new List<int> { 1, 5, 1, 3 };

            Assert.Equal(5, anInteger.Map(_ => _ + 2));
            Assert.Equal(3, listOfInts.Map(_ => new HashSet<int>(_)).Count);

        }
    }
}
