using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SomeExtensions.Functional.Tests
{
    public class SequencesTests
    {
        [Fact]
        public void SequencesForFuncTest()
        {
            Assert.Equal(5,
                        ((Func<string>)(() => "Hello"))
                            .DoThen<string, int>((input) => input.Length)
                );
        }

        [Fact]
        public void SequencesForActionTest()
        {
            Assert.True(
                        ((Action)(() => { }))
                            .DoThen<bool>(() => true)
                );
        }
    }
}
