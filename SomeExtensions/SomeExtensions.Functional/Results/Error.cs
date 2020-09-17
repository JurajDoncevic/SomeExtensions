using System;
using System.Collections.Generic;
using System.Text;

namespace SomeExtensions.Functional.Results
{
    public class Error
    {
        public Error(int errorCode, Exception exception, string message)
        {
            ErrorCode = errorCode;
            Exception = exception;
            Message = message;
        }

        public int ErrorCode { get; }
        public Exception Exception { get; }
        public string Message { get; }
    }
}
