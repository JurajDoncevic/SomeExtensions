using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SomeExtensions.Functional.Results
{
    public class Result
    {
        internal Result(IEnumerable<Error> errors)
        {
            Errors = errors ?? new List<Error>();
            IsSuccessful = !Errors.Any();
        }

        public bool IsSuccessful { get; }
        public IEnumerable<Error> Errors { get; }

        public static TResult CreateSuccessResult<TResult>()
                     where TResult : Result
                => ReflectionHelpers
                     .CreateInstanceWithPublicOrNonPublicConstructor<TResult>(null);

        public static TResult CreateErrorResult<TResult>(params Error[] errors)
                where TResult : Result
            => ReflectionHelpers
                .CreateInstanceWithPublicOrNonPublicConstructor<TResult>(errors);
    }
}
