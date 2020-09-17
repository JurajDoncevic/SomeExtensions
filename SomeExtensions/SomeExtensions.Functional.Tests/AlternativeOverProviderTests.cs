using SomeExtensions.Functional.Tests.Mocking;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SomeExtensions.Functional.Tests
{
    public class AlternativeOverProviderTests
    {
        [Fact]
        public void AlternativeAltTest()
        {
            var result =
            Disposable.Using(
                () => new MockProvider(),
                (provider) => Alternative.Alt(provider,
                                              (provider) => provider.GetNullModel(1),
                                              (provider) => provider.GetNullModel(2),
                                              (provider) => provider.GetNullModel(3),
                                              (provider) => provider.GetModel(4),
                                              (provider) => provider.GetModel(5),
                                              (provider) => provider.GetModel(6)
                                              )
                );

            Assert.NotNull(result);
            Assert.Equal(4, result.Id);
        }

        [Fact]
        public void AlternativeFlowAltTest()
        {
            var result =
            Disposable.Using(
                () => new MockProvider(),
                (provider) => provider.Alt((provider) => provider.GetNullModel(1),
                                           (provider) => provider.GetNullModel(2),
                                           (provider) => provider.GetNullModel(3),
                                           (provider) => provider.GetModel(4),
                                           (provider) => provider.GetModel(5),
                                           (provider) => provider.GetModel(6)
                                           )
                );

            Assert.NotNull(result);
            Assert.Equal(4, result.Id);
        }
    }
}
