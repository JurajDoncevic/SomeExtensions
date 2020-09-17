using System;
using System.Collections.Generic;
using System.Text;

namespace SomeExtensions.Functional.Tests.Mocking
{
    public class MockProvider : IDisposable
    {
        public bool IsDisposed { get; private set; } = false;

        public MockModel GetModel(int id)
        {
            return new MockModel() { Id = id };
        }

        public MockModel ThrowException()
        {
            throw new Exception();
        }

        public MockModel GetNullModel(int id)
        {
            return null;
        }

        public List<MockModel> GetModels()
        {
            return new List<MockModel>() { new MockModel() { Id = 1 },
                                           new MockModel() { Id = 1 }, 
                                           new MockModel() { Id = 1 },
                                           new MockModel() { Id = 1 } };
        }

        public List<MockModel> GetNullModels()
        {
            return null;
        }

        public void Dispose()
        {
            IsDisposed = true;
        }
    }
}
