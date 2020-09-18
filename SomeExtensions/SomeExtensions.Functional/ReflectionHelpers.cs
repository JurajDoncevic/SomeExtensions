using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SomeExtensions.Functional
{
    public static class ReflectionHelpers
    {
        public static T CreateInstanceWithPublicOrNonPublicConstructor<T>(params object[] parameters)
        {
            string type = typeof(T).ToString();
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
            var obj = Activator.CreateInstance(typeof(T), bindingFlags, null, new object[] { parameters }, CultureInfo.CurrentCulture);
            return (T)obj;
        }
    }
}
