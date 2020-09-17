using System;
using System.Collections.Generic;
using System.Text;

namespace SomeExtensions.Functional
{
    public static class Mapping
    {
        /// <summary>
        /// Map is like Select, but works on an iterable or non iterable object. It maps the entire object, not individual components of list.
        /// </summary>
        /// <typeparam name="TFromType"></typeparam>
        /// <typeparam name="TToType"></typeparam>
        /// <param name="target">Target object</param>
        /// <param name="func">Mapping function</param>
        /// <returns>Mapped object</returns>
        public static TToType Map<TFromType, TToType>(this TFromType target, Func<TFromType, TToType> func) =>
            func(target);
    }
}
