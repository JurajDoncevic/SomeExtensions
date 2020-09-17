using System;
using System.Collections.Generic;
using System.Text;

namespace SomeExtensions.Functional.Results
{
    public class DataResult<TData> : Result
    {
        internal DataResult(
                TData data,
                IEnumerable<Error> errors)
            : base(errors)
        => Data = data;

        internal DataResult(Error[] errors)
              : base(errors)
        => Data = default(TData);

        public static DataResult<TData> CreateSuccessResult(TData data)
        => new DataResult<TData>(data, null);

        public DataResult<TNewType> CreateWithMap<TNewType>(Func<TData, TNewType> map)
        => new DataResult<TNewType>(map(Data),
                Errors);

        public TData Data { get; }

    }
}
