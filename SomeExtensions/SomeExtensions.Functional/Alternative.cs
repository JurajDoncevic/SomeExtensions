using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SomeExtensions.Functional
{
    public static class Alternative
    {
        /// <summary>
        /// Executes functions sequentialy until one returns a result. Returns first non-default non-null result.
        /// </summary>
        /// <typeparam name="TInput">Input type</typeparam>
        /// <typeparam name="TOutput">Output type</typeparam>
        /// <param name="target">Target object over which the functions are called</param>
        /// <param name="funcs">Alternate functions array</param>
        /// <returns>Non-default result</returns>
        public static TOutput Alt<TInput, TOutput>(this TInput target, params Func<TInput, TOutput>[] funcs) =>
            funcs.First()
                 .Invoke(target)
                 .IfDefaultOrNullDoNext(funcs.Skip(1).ToArray(), target);

        /// <summary>
        /// Helper method. Determines whether to execute alternate functions.
        /// </summary>
        /// <typeparam name="TInput">Input type</typeparam>
        /// <typeparam name="TOutput">Output type</typeparam>
        /// <param name="target">Target over which the functions are called</param>
        /// <param name="elseFuncs">Alternate functions</param>
        /// <param name="input">First function result</param>
        /// <returns>Frowards the result of the first function or result of the alternate function</returns>
        private static TOutput IfDefaultOrNullDoNext<TInput, TOutput>(this TOutput target, Func<TInput, TOutput>[] elseFuncs, TInput input) =>
            EqualityComparer<TOutput>.Default.Equals(target, default(TOutput)) || target == null
                ? input.Alt<TInput, TOutput>(elseFuncs)
                : target;
    }
}
