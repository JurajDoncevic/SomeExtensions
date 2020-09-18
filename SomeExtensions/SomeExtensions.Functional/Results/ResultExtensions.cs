using System;
using System.Collections.Generic;
using System.Text;

namespace SomeExtensions.Functional.Results
{
    public static class ResultExtensions
    {
        public static DataResult<TData> CreateSuccessResult<TData>(this TData data)
        => new DataResult<TData>(data, null);
    }
}
