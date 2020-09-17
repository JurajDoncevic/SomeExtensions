using System;
using System.Collections.Generic;
using System.Text;

namespace SomeExtensions.Functional.Tests.Mocking
{
    public class MockService : IDisposable
    {
        public bool IsDisposed { get; private set; } = false; 
        public bool DoSomethingThatNeverFails()
        {
            return true;
        }

        public bool DoSomethingThatAlwaysFails()
        {
            return false;
        }

        public bool DoSomethingThatAlwaysThrowsException()
        {
            throw new Exception();
        }

        public MockModel DoSomethingOnMockObject(MockModel model)
        {
            model.Data = "Data changed";
            return model;
        }

        public bool IsModelDataChanged(MockModel model)
        {
            return !model.Data.Equals(MockModel.ORIGINAL_DATA);
        }

        public void Dispose()
        {
            IsDisposed = true;
        }
    }
}
