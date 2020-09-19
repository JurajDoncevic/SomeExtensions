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

        [Fact]
        public void WhenAllTrueDoTrueTest()
        {
            Assert.NotNull(Sequences.WhenAllTrueDoElse(() => "this is a string",
                                                       () => null,
                                                       () => true,
                                                       () => 1 < 2,
                                                       () => 1 == 1));
        }

        [Fact]
        public void WhenAllTrueDoFalseTest()
        {
            Assert.Null(Sequences.WhenAllTrueDoElse(() => "this is a string",
                                                    () => null,
                                                    () => true,
                                                    () => false,
                                                    () => 1 == 1));
        }
    }
}
