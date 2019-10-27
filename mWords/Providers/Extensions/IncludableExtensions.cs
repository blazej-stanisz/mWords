using Microsoft.EntityFrameworkCore;
using mWords.Providers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace mWords.Providers.Extensions
{


    public static class IncludableExtensions
    {
        public static IIncludable<TEntity, TProperty> Include<TEntity, TProperty>(
            this IIncludable<TEntity> includes,
            Expression<Func<TEntity, TProperty>> propertySelector)
            where TEntity : class
        {
            var result = ((IncludableMany<TEntity>)includes).Input
                .Include(propertySelector);

            return new IncludableMany<TEntity, TProperty>(result);
        }

        //public static IIncludable<TEntity, TOtherProperty>
        //    ThenInclude<TEntity, TOtherProperty, TProperty>(
        //        this IIncludable<TEntity, TProperty> includes,
        //        Expression<Func<TProperty, TOtherProperty>> propertySelector)
        //    where TEntity : class
        //{
        //    var result = ((IncludableMany<TEntity, TProperty>)includes)
        //        .IncludableInput.ThenInclude(propertySelector);
        //    return new IncludableMany<TEntity, TOtherProperty>(result);
        //}

        //public static IIncludable<TEntity, TOtherProperty>
        //    ThenInclude<TEntity, TOtherProperty, TProperty>(
        //        this IIncludable<TEntity, IEnumerable<TProperty>> includes,
        //        Expression<Func<TProperty, TOtherProperty>> propertySelector)
        //    where TEntity : class
        //{
        //    var result = ((IncludableMany<TEntity, IEnumerable<TProperty>>)includes)
        //        .IncludableInput.ThenInclude(propertySelector);
        //    return new IncludableMany<TEntity, TOtherProperty>(result);
        //}
    }
}
