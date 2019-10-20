using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace mWords.Providers
{
    public interface IGenericProvider
    {
        void Add<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        bool Exists<TEntity>(long id) where TEntity : class;
        TEntity Get<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        List<TAppModel> GetAll<TEntity, TAppModel>() where TEntity : class;
        TAppModel GetById<TEntity, TAppModel>(long id) where TEntity : class;
        IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class;
    }
}