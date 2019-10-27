using mWords.Providers.Common;
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
        /// <summary>
        /// Get app object by Id.
        /// </summary>
        /// <param name="id">The entity object Id.</param>
        /// <returns>App model</returns>
        TAppModel Get(long id);

        TAppModel GetTest(long id, Func<IIncludable<TEntity>, IIncludable> includes = null);

        /// <summary>
        /// Get app objects list matching predicate.
        /// </summary>
        /// <param name="predicate">The predicate to select subset list.</param>
        /// <returns>The listo of app model objects.</returns>
        List<TAppModel> Get(Expression<Func<TEntity, bool>> predicate);

        List<TAppModel> GetTest2(Expression<Func<TEntity, bool>> predicate, Func<IIncludable<TEntity>, IIncludable> includes = null);

        /// <summary>
        /// Get all app objects from database.
        /// </summary>
        /// <returns>The list of all app models objects.</returns>
        List<TAppModel> GetAll();

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
       
        bool Exists(long id);
      
        IQueryable<TEntity> GetQueryable();
    }
}