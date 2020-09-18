using SomeExtensions.Functional.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SomeExtensions.Functional.Tests
{
    public class ResultTests
    {
        [Fact]
        public void TestDataResultCreation()
        {
            List<string> list = new List<string>() { "hello", "this", "is", "a", "string", "list" };
            DataResult<List<string>> dataResult = null;
            var exception = Record.Exception(() =>
            {
                dataResult = DataResult<List<string>>.CreateSuccessResult(list);
            });

            Assert.Null(exception);
            Assert.NotNull(dataResult);
            Assert.Equal(6, dataResult.Data.Count);
        }

        [Fact]
        public void TestErrorDataResultCreation()
        {
            DataResult<List<string>> dataResult = null;
            var exception = Record.Exception(() =>
            {
                dataResult = Result.CreateErrorResult<DataResult<List<string>>>(new Error(ErrorCode.ExceptionThrown, new Exception(), "1"), new Error(ErrorCode.ExceptionThrown, new Exception(), "2"));
            });

            Assert.Null(exception);
            Assert.NotNull(dataResult);
            Assert.Equal(2, dataResult.Errors.Count());
        }
    }
}
