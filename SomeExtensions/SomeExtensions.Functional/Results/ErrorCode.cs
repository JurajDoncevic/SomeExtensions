using System;
using System.Collections.Generic;
using System.Text;

namespace SomeExtensions.Functional.Results
{
    public class ErrorCode
    {
        public const int Unknown = 0;
        public const int ExceptionThrown = 1;
        public const int FailedWithoutMessage = 2;
    }
}
