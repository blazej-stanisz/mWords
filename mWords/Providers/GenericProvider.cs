using AutoMapper;
using Microsoft.Extensions.Logging;
using mWords.Data;
using mWords.Providers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace mWords.Providers
{
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

        public TAppModel GetById(long id)
        {
            var entity = this._context.Set<TEntity>().Find(id);
            return this._mapper.Map<TAppModel>(entity);
        }

        public List<TAppModel> GetAll()
        {
            var entities = this._context.Set<TEntity>().ToList();
            return this._mapper.Map<List<TAppModel>>(entities);
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return this._context.Set<TEntity>().AsQueryable();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            var querable = this.GetQueryable();
            return querable.FirstOrDefault(predicate);
        }

        public bool Exists(long id)
        {
            return this.GetById(id) != null;
        }

        public void Add(TEntity entity)
        {
            this._context.Set<TEntity>().Add(entity);
            this._context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            this._context.Set<TEntity>().Remove(entity);
            this._context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            this._context.Set<TEntity>().Update(entity);
            this._context.SaveChanges();
        }
    }
}
