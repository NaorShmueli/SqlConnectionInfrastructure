using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTemplate.Abstraction.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> Add(T entity);
        T Update(T entity);
        Task<T> Get(Guid id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T,bool>> predicate);
        Task<bool> Save();

    }
}
