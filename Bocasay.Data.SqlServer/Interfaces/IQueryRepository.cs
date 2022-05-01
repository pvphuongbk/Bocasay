using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.SqlServer.Interfaces
{
    public interface IQueryRepository<T> where T : class
    {
        T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);


        IQueryable<T> GetMany(Expression<Func<T, bool>> where);


        T Get(Expression<Func<T, bool>> where);

        T GetById(object id);

        Task<T> GetByIdAsync(object id);

        Task<T> GetAsync(Expression<Func<T, bool>> where);


        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate);

        Task<int> CountWhere(Expression<Func<T, bool>> predicate);

        Task<int> CountAll();
    }
}
