using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.SqlServer.Interfaces
{
    public interface ICommandRepository<T> where T : class
    {
        void Insert(T entity);

        void Update(T entity);

        void Remove(T entity);

        void Remove(object id);

        void SoftDelete(T entity);
        void MultipleSoftDelete(IQueryable<T> entities);
        void RemoveMultiple(List<T> entities);
        void RemoveMultiple(IQueryable<T> entities);
        void InsertMultiple(IEnumerable<T> entities);
        void UpdateMultiple(IQueryable<T> entities);

        Task InsertsAsync(List<T> entities);
        Task UpdatesAsync(List<T> entities);
    }
}
