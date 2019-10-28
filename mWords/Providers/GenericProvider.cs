using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mWords.Data;
using mWords.Providers.Common;
using mWords.Providers.Extensions;
using mWords.Providers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace mWords.Providers
{
    public static class ObjectExtensionMethods
    {
        public static IQueryable<T> ToQueryable<T>(this T instance)
        {
            var a = new[] { instance }.AsQueryable();
            return a;
        }
    }

    public abstract class GenericProvider<TEntity, TAppModel> : IGenericProvider<TEntity, TAppModel> 
        where TEntity : class
        where TAppModel : class
    {
        private readonly ILogger<GenericProvider<TEntity, TAppModel>> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GenericProvider(ILogger<GenericProvider<TEntity, TAppModel>> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public List<TAppModel> Get(Expression<Func<TEntity, bool>> predicate)
        {
            var querable = this.GetQueryable();
            var selected = querable.Where(predicate);
            return this._mapper.Map<List<TAppModel>>(selected);
        }

        public List<TAppModel> Get(Expression<Func<TEntity, bool>> predicate, Func<IIncludable<TEntity>, IIncludable> includes = null)
        {
            var querable = this.GetQueryable();
            var selected = querable.Where(predicate).IncludeMultiple(includes);
            return this._mapper.Map<List<TAppModel>>(selected);
        }

        public List<TAppModel> GetAll()
        {
            var entities = this._context.Set<TEntity>();
            return this._mapper.Map<List<TAppModel>>(entities);
        }

        public void Add(TEntity entity)
        {
            this._context.Set<TEntity>().Add(entity);
            this._context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            this._context.Set<TEntity>().Update(entity);
            this._context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            this._context.Set<TEntity>().Remove(entity);
            this._context.SaveChanges();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return this._context.Set<TEntity>().AsQueryable();
        }       
    }
}
