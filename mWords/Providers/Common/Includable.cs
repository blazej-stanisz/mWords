﻿using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mWords.Providers.Common
{
    public interface IIncludable { }

    public interface IIncludable<out TEntity> : IIncludable { }

    public interface IIncludable<out TEntity, out TProperty> : IIncludable<TEntity> { }

    internal class IncludableMany<TEntity> : IIncludable<TEntity> where TEntity : class
    {
        internal IQueryable<TEntity> Input { get; }

        internal IncludableMany(IQueryable<TEntity> queryable)
        {
            // C# 7 syntax, just rewrite it "old style" if you do not have Visual Studio 2017
            Input = queryable ?? throw new ArgumentNullException(nameof(queryable));
        }
    }

    internal class IncludableMany<TEntity, TProperty> :
        IncludableMany<TEntity>, IIncludable<TEntity, TProperty>
        where TEntity : class
    {
        internal IIncludableQueryable<TEntity, TProperty> IncludableInput { get; }

        internal IncludableMany(IIncludableQueryable<TEntity, TProperty> queryable) :
            base(queryable)
        {
            IncludableInput = queryable;
        }
    }
}
