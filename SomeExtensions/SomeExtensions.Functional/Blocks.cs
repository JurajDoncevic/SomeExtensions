using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SomeExtensions.Functional
{
    public static class Disposable
    {
        public static TResult Using<TWith, TResult>(
                Func<TWith> factory,
                Func<TWith, TResult> operate)
            where TWith : IDisposable
        {
            using (var with = factory())
            {
                return operate(with);
            }
        }

        public async static Task<TResult> UsingAsync<TWith, TResult>(
                Func<TWith> factory,
                Func<TWith, Task<TResult>> operate)
            where TWith : IDisposable
        {
            using (var with = factory())
            {
                return await operate(with);
            }
        }
    }

    public static class Exceptions
    {
        public static TResult Try<TResult>(
            Func<TResult> operate,
            Func<Exception, TResult> catchOperate)
        {
            try
            {
                return operate();
            }
            catch (Exception ex)
            {
                return catchOperate(ex);
            }
        }

        public async static Task<TResult> TryAsync<TResult>(
             Func<Task<TResult>> operate,
             Func<Exception, TResult> catchOperate)
        {
            try
            {
                return await operate();
            }
            catch (Exception ex)
            {
                return catchOperate(ex);
            }
        }

    }
}
