using SomeExtensions.Functional.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SomeExtensions.Functional
{
    public static class Sequences
    {
        public static TResult DoThen<TResult>(this Action doFirst, Func<TResult> then)
        {
            doFirst.Invoke();
            return then.Invoke();
        }

        public static TResult DoThen<TInput, TResult>(this Func<TInput> doFirst, Func<TInput, TResult> then) =>
            then.Invoke(doFirst.Invoke());

        public static TResult WhenAllTrueDoElse<TResult>(Func<TResult> doFunc, Func<TResult> elseFunc, params Func<bool>[] predicates) =>
            predicates.All(_ => _.Invoke())
            ? doFunc.Invoke()
            : elseFunc.Invoke();
    }
}
