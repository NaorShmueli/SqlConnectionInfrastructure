using EntityFrameworkTemplate.Abstraction.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTemplate.Abstraction
{
    public abstract class GenericRepository<T> : IRepository<T> where T : IEntity
    {
        protected DbContext _dbContext;
        private readonly ILogger<GenericRepository<T>> _logger;
        public GenericRepository(DbContext dbContext, ILogger<GenericRepository<T>> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public async Task<T> Add(T entity)
        {
            try
            {
                await _dbContext.AddAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,$"Failed Add entity with id = {entity.Id}");
            }
            return entity;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _dbContext.Set<T>().AsQueryable().Where(predicate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed Find with predicate entity {predicate.Parameters}");

                throw;
            }
        }

        public async Task<T> Get(Guid id)
        {
            try
            {
                return await _dbContext.FindAsync<T>(id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed Get entity with id = {id}");
                return default(T);
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _dbContext.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed GetAll");
                return default(IEnumerable<T>);
            }
        }

        public async Task<bool> Save()
        {
            var result = true;
            try
            {
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex,$"Failed SaveChanges");
                result = false;
            }
            return result;
        }

        public T Update(T entity)
        {
            try
            {
                _dbContext.Update<T>(entity);
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed Update entity with id  {entity.Id}");
                return default(T);
            }
        }
    }
}
