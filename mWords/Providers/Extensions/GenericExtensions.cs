using mWords.Providers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mWords.Providers.Extensions
{
    

    public static class GenericExtensions
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query,
            Func<IIncludable<T>, IIncludable> includes)
            where T : class
        {
            if (includes == null)
                return query;

            var includable = (IncludableMany<T>)includes(new IncludableMany<T>(query));
            return includable.Input;
        }

        //public static T IncludeMultiple<T>(this T query,
        //    Func<IIncludable<T>, IIncludable> includes)
        //    where T : class
        //{
        //    if (includes == null)
        //        return query;

        //    var includable = (IncludableMany<T>)includes(new IncludableMany<T>(query.ToQueryable()));
        //    var a = includable.Input.FirstOrDefault();
        //    return includable.Input.FirstOrDefault();
        //}
    }
}
