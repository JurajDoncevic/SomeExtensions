using SomeExtensions.Functional.Tests.Mocking;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SomeExtensions.Functional.Tests
{
    public class BlocksOverProviderTest
    {
        [Fact]
        public void TestTryCatchOnThrow()
        {
            MockProvider provider = new MockProvider();
            Exception exception = null;
            var result =
                Exceptions.Try(
                    () => provider.ThrowException(),
                    (ex) => { exception = ex; return provider.GetModel(1); }
                );

            Assert.NotNull(exception);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void TestTryCatchOnWithoutThrow()
        {
            MockProvider provider = new MockProvider();
            Exception exception = null;
            var result =
                Exceptions.Try(
                    () => provider.GetModels(),
                    (ex) => { exception = ex; return provider.GetModels(); }
                );

            Assert.Null(exception);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestUsingBlockResult()
        {
            var result =
            Disposable.Using(
                () => new MockProvider(),
                (provider) => provider.GetModels()
                );

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void TestUsingBlockDisposing()
        {
            MockProvider provider = null;
            var result =
            Disposable.Using(
                () => new MockProvider(),
                (_provider) => { provider = _provider; return _provider.GetModel(1); }
                );

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.True(provider.IsDisposed);
        }

        [Fact]
        public void TestTryCatchExceptionOverUsing()
        {
            Exception exception = null;

            var result =
            Exceptions.Try(
                () => Disposable.Using(
                        () => new MockProvider(),
                        (_provider) => _provider.ThrowException()
                        ),
                (ex) => { exception = ex; return new MockModel(); }
                );

            Assert.NotNull(result);
            Assert.Equal(0, result.Id);
            Assert.NotNull(exception);
        }
    }
}
