using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace mWords.Providers.Interfaces
{
    public interface IGenericProvider<TEntity, TAppModel>
        where TEntity : class
        where TAppModel : class
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        bool Exists(long id);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        List<TAppModel> GetAll();
        TAppModel GetById(long id);
        IQueryable<TEntity> GetQueryable();
        void Update(TEntity entity);
    }
}