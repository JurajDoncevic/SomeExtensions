using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SomeExtensions.Functional
{
    public static class Validation
    {
        /*Inspired by Simon Painter*/
        /// <summary>
        /// Checks if the given input object is valid by all the given predicates
        /// </summary>
        /// <typeparam name="TInput">Type of the input object</typeparam>
        /// <param name="target">Target object that is to be validated</param>
        /// <param name="predicates">Predicates to check validity</param>
        /// <returns>True if passes predicates, else false</returns>
        public static bool Validate<TInput>(this TInput target, params Func<TInput, bool>[] predicates) =>
            predicates.All(_ => _.Invoke(target));
    }
}
