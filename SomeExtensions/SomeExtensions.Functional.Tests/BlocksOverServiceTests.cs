using SomeExtensions.Functional.Tests.Mocking;
using SomeExtensions.Functional;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Reflection.Metadata.Ecma335;

namespace SomeExtensions.Functional.Tests
{
    public class BlocksOverServiceTests
    {
        [Fact]
        public void TestTryCatchOnThrow()
        {
            MockService service = new MockService();
            Exception exception = null;
            var result =
                Exceptions.Try(
                    () => service.DoSomethingThatAlwaysThrowsException(),
                    (ex) => { exception = ex; return service.DoSomethingThatNeverFails(); }
                );

            Assert.NotNull(exception);
            Assert.True(result);
        }

        [Fact]
        public void TestTryCatchOnWithoutThrow()
        {
            MockService service = new MockService();
            Exception exception = null;
            var result =
                Exceptions.Try(
                    () => service.DoSomethingThatNeverFails(),
                    (ex) => { exception = ex; return service.DoSomethingThatAlwaysFails(); }
                );

            Assert.Null(exception);
            Assert.True(result);
        }

        [Fact]
        public void TestUsingBlockResult()
        {
            var result =
            Disposable.Using(
                () => new MockService(),
                (service) => service.DoSomethingThatNeverFails()
                );

            Assert.True(result);
        }

        [Fact]
        public void TestUsingBlockDisposing()
        {
            MockService service = null;
            var result =
            Disposable.Using(
                () => new MockService(),
                (_service) => { service = _service; return _service.DoSomethingThatNeverFails(); }
                );

            Assert.True(result);
            Assert.True(service.IsDisposed);
        }

        [Fact]
        public void TestTryCatchExceptionOverUsing()
        {
            Exception exception = null;

            var result =
            Exceptions.Try(
                () => Disposable.Using(
                        () => new MockService(),
                        (_service) => _service.DoSomethingThatAlwaysThrowsException()
                        ),
                (ex) => { exception = ex; return false; }
                );

            Assert.False(result);
            Assert.NotNull(exception);
        }
    }
}
