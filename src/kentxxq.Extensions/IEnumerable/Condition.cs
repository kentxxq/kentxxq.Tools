using System;
using System.Collections.Generic;

namespace kentxxq.Extensions.IQueryable
{
    public static class Condition
    {
        public static IEnumerable<T> If<T>(this IEnumerable<T> source, bool condition, Func<IEnumerable<T>, IEnumerable<T>> branch)
        {
            return condition ? branch(source) : source;
        }
    }
}