using System;
using System.Linq;
using Xunit;

namespace SomeExtensions.Functional.Tests
{
    public class ValidationTests
    {
        [Fact]
        public void TestValidationOverStringForAllTruePredicates()
        {
            string testString = "THIS IS A TEST STRING IN CAPS";

            Func<string, bool> isShorterThan50 = (string x) => x.Length < 50;
            Func<string, bool> isAllCaps = (string x) => x.Replace(" ",  "").All(char.IsUpper);
            Func<string, bool> isNotNullOrEmpty = (string x) => !string.IsNullOrWhiteSpace(x);
            Func<string, bool> hasSpaces = (string x) => x.Contains(' ');


            Assert.True(testString.Validate(isShorterThan50,
                                            isNotNullOrEmpty,
                                            isAllCaps,
                                            hasSpaces));

        }

        [Fact]
        public void TestValidationOverStringForOneFalsePredicates()
        {
            string testString = "THIS IS A TEST STRING IN CAPS";

            Func<string, bool> isShorterThan50 = (string x) => x.Length < 50;
            Func<string, bool> isAllCaps = (string x) => x.Replace(" ", "").All(char.IsUpper);
            Func<string, bool> isNotNullOrEmpty = (string x) => !string.IsNullOrWhiteSpace(x);
            Func<string, bool> hasSpaces = (string x) => x.Contains(' ');
            Func<string, bool> failingPredicate = (string x) => false;


            Assert.False(testString.Validate(isShorterThan50,
                                            isNotNullOrEmpty,
                                            failingPredicate,
                                            isAllCaps,
                                            hasSpaces
                                            ));

        }

        [Fact]
        public void TestValidationOverStringForAllFalsePredicates()
        {
            string testString = "THIS IS A TEST STRING IN CAPS";

            Func<string, bool> failingPredicate = (string x) => false;


            Assert.False(testString.Validate(failingPredicate,
                                             failingPredicate,
                                             failingPredicate));

        }
    }
}
