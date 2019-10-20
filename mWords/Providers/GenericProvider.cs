using AutoMapper;
using Microsoft.Extensions.Logging;
using mWords.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace mWords.Providers
{
    public class GenericProvider : IGenericProvider
    {
        private readonly ILogger<GenericProvider> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GenericProvider(ILogger<GenericProvider> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public TAppModel GetById<TEntity, TAppModel>(long id) where TEntity : class
        {
            var entity = this._context.Set<TEntity>().Find(id);
            return this._mapper.Map<TAppModel>(entity);
        }

        public List<TAppModel> GetAll<TEntity, TAppModel>() where TEntity : class
        {
            var entities = this._context.Set<TEntity>().ToList();
            return this._mapper.Map<List<TAppModel>>(entities);
        }

        public IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class
        {
            return this._context.Set<TEntity>().AsQueryable();
        }

        public TEntity Get<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var querable = this.GetQueryable<TEntity>();
            return querable.FirstOrDefault(predicate);
        }

        public bool Exists<TEntity>(long id) where TEntity : class
        {
            var entity = this._context.Set<TEntity>().Find(id);
            return entity != null;
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            this._context.Set<TEntity>().Add(entity);
            this._context.SaveChanges();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            this._context.Set<TEntity>().Remove(entity);
            this._context.SaveChanges();
        }
    }
}
