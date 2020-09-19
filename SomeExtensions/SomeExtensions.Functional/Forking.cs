using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SomeExtensions.Functional
{
    public static class Forking
    {
        /// <summary>
        /// Executes the prong functions and finalizes the result with the finalize function. Used to aggergate multiple function results.
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="target">Target object</param>
        /// <param name="finalizeFunc">Finalizing function</param>
        /// <param name="prongs">Prong function</param>
        /// <returns></returns>
        public static TOutput Fork<TInput, TOutput>(this TInput target, Func<IEnumerable<TOutput>, TOutput> finalizeFunc,
                                                    params Func<TInput, TOutput>[] prongs) =>
            prongs.Select(_ => _(target)).Map(finalizeFunc);

        public static TOutput Fork<TOutput>(Func<IEnumerable<TOutput>, TOutput> finalizeFunc,
                                                    params Func<TOutput>[] prongs) =>
            prongs.Select(_ => _.Invoke()).Map(finalizeFunc);
    }
}
