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
    public abstract class GenericRepository<T> : IRepository<T> where T : Entity
    {
        protected DbContext _dbContext;
        private readonly ILogger<GenericRepository<T>> _logger;
        public GenericRepository(DbContext dbContext, ILogger<GenericRepository<T>> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public virtual async Task<T> Add(T entity)
        {
            try
            {
                await _dbContext.AddAsync(entity);
                await this.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,$"Failed Add entity with id = {entity.Id}");
            }
            return entity;
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
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

        public virtual async Task<T> Get(Guid id)
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

        public virtual IEnumerable<T> GetAll()
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

        public virtual async Task<bool> SaveAsync()
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

        public virtual Task<T> Update(T entity)
        {
            try
            {
                _dbContext.Set<T>().Attach(entity);
                //_dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return Task.FromResult(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed Update entity with id  {entity.Id}");
                return default(Task<T>);
            }
        }

        public virtual bool Delete(T entity)
        {
            try
            {
                _dbContext.Remove(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed Delete entity with id  {entity.Id}");
                return default;
            }
        }
    }
}
