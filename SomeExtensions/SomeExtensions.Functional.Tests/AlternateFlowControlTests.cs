using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SomeExtensions.Functional.Tests
{
    public class AlternateFlowControlTests
    {
        [Fact]
        public void TestAltWhenOption1DoesNotDefault()
        {
            string testString = "This Is Some Test String";

            Func<string, string> toUpper = (string x) => x.ToUpper();
            Func<string, string> toLower = (string x) => x.ToLower();

            Assert.Equal(testString.ToUpper(), testString.Alt(toUpper, toLower));
        }

        [Fact]
        public void TestAltWhenOption1Defaults()
        {
            string testString = "This Is Some Test String";

            Func<string, string> toDefault = (string x) => default(string);
            Func<string, string> toLower = (string x) => x.ToLower();

            Assert.Equal(testString.ToLower(), testString.Alt(toDefault, toLower));
        }

        [Fact]
        public void TestAltWhenOptionsDoNotDefault()
        {
            string testString = "This Is Some Test String";

            Func<string, string> toUpper = (string x) => x.ToUpper();
            Func<string, string> toLower = (string x) => x.ToLower();
            Func<string, string> toPaddedBy2 = (string x) => x.PadRight(2).PadLeft(2);
            Func<string, string> toTrimmed = (string x) => x.TrimEnd('\n').TrimStart(' ');

            Assert.Equal(testString.ToUpper(), testString.Alt(toUpper,
                                                              toPaddedBy2,
                                                              toTrimmed,
                                                              toLower));
        }

        [Fact]
        public void TestAltWhenAnOptionDefaults()
        {
            string testString = "This Is Some Test String";

            Func<string, string> toDefault = (string x) => default(string);
            Func<string, string> toLower = (string x) => x.ToLower();

            Assert.Equal(testString.ToLower(), testString.Alt(toDefault,
                                                              toDefault,
                                                              toDefault,
                                                              toLower));
        }

        [Fact]
        public void TestAltWhenAltOptionsDefault()
        {
            string testString = "This Is Some Test String";

            Func<string, string> toDefault = (string x) => default(string);
            Func<string, string> toLower = (string x) => x.ToLower();
            Func<string, string> toUpper = (string x) => x.ToUpper();

            Assert.Equal(testString.ToLower(), testString.Alt(toLower,
                                                              toDefault,
                                                              toDefault,
                                                              toUpper));
        }

        [Fact]
        public void TestAltWhenAltOptionsNull()
        {
            string testString = "This Is Some Test String";

            Func<string, string> toNull = (string x) => null;
            Func<string, string> toLower = (string x) => x.ToLower();
            Func<string, string> toUpper = (string x) => x.ToUpper();

            Assert.Equal(testString.ToLower(), testString.Alt(toLower,
                                                              toNull,
                                                              toNull,
                                                              toUpper));
        }

        [Fact]
        public void TestAltWhenAnOptionNulls()
        {
            string testString = "This Is Some Test String";

            Func<string, string> toNull = (string x) => null;
            Func<string, string> toLower = (string x) => x.ToLower();

            Assert.Equal(testString.ToLower(), testString.Alt(toNull,
                                                              toNull,
                                                              toNull,
                                                              toLower));
        }


        [Fact]
        public void TestAltWhenOptionThrowsException()
        {
            string testString = "This Is Some Test String";

            Func<string, string> throwException = (string x) => throw new Exception("This is an exception");
            Func<string, string> toUpper = (string x) => x.ToUpper();

            Assert.Throws<Exception>(() => testString.Alt(throwException,
                                                          throwException,
                                                          throwException,
                                                          toUpper));
        }

        [Fact]
        public void TestForkMethod()
        {
            var input = "aaabbbcccddd";

            var output = input.Fork(_ => _.Sum(),
                                    _=>_.Count(x => x == 'a'),
                                    _=>_.Count(x => x == 'b'),
                                    _=>_.Count(x => x == 'c')
                                    );
            Assert.Equal(9, output);
        }
    }
}
