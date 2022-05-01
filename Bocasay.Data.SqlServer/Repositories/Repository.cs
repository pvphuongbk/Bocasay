using Bocasay.Data.SqlServer.Base;
using Bocasay.Data.SqlServer.EF;
using Bocasay.Data.SqlServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Data.SqlServer.Repositories
{
    public class Repository<D, T> : IRepository<T>, IDisposable where T : class where D : CommonDBContext
    {
        private CommonDBContext _context;

        public Repository(D context)
        {
            _context = context;
        }

        protected CommonDBContext DbContext
        {
            get
            {
                if (_context == null)
                    throw new Exception("Context must be initial");
                return _context;
            }
        }

        #region Command functions

        public virtual void Remove(object id)
        {
            var entity = GetById(id);
            Remove(entity);
        }

        public virtual void RemoveMultiple(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
        public virtual void RemoveMultiple(IQueryable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
        public virtual void Remove(T entity)
        {
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.IsDeleted = true;
            }
            _context.Set<T>().Remove(entity);
        }
        public virtual void Insert(T entity)
        {
            _context.Add(entity);
        }
        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public virtual void UpdateMultiple(IQueryable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
        }
        //public Task InsertAsync(T entity)
        //{
        //    _context.Set<T>().Add(entity);
        //    //return Task.FromResult(_context.SaveChangesAsync());
        //    return Task.CompletedTask;
        //}

        //public Task UpdateAsync(T entity)
        //{
        //    _context.Entry(entity).State = EntityState.Modified;

        //    return Task.CompletedTask;
        //    //return _context.SaveChangesAsync();
        //}

        public void SoftDelete(T entity)
        {
            if (entity is BaseEntity)
            {
                _context.Entry(entity).State = EntityState.Modified;
                (entity as BaseEntity).IsDeleted = true;
                Update(entity);
            }
        }
        public void MultipleSoftDelete(IQueryable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Modified;
                (entity as BaseEntity).IsDeleted = true;
            }
            _context.UpdateRange(entities);
        }

        public virtual async Task InsertsAsync(List<T> entities)
        {
            await _context.AddRangeAsync(entities);
        }

        public virtual async Task UpdatesAsync(List<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
            await Task.CompletedTask;
        }

        //public Task RemoveAsync(T entity)
        //{
        //    _context.Set<T>().Remove(entity);

        //    return Task.CompletedTask;
        //    //return _context.SaveChangesAsync();
        //}

        //public Task RemoveAsync(object id)
        //{
        //    var entity = _context.Set<T>().FindAsync(id).Result;
        //    _context.Set<T>().Remove(entity);

        //    //return _context.SaveChangesAsync();
        //    return Task.CompletedTask;
        //} 
        #endregion

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        #region Query functions
        public virtual IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items;
        }

        public virtual IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items.Where(predicate);
        }

        public virtual IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _context.Set<T>().Where(where);
        }


        public virtual T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(predicate);
        }


        public virtual T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }


        public virtual T Get(Expression<Func<T, bool>> where)
        {
            var entity = _context.Set<T>().Where(where).FirstOrDefault();
            return entity;
        }
        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> where)
        {
            var entity = await _context.Set<T>().Where(where).FirstOrDefaultAsync();
            return entity;
        }


        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> items = _context.Set<T>();

            return Task.FromResult(items.Where(predicate).AsEnumerable());
        }

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().CountAsync(predicate);
        }

        public Task<int> CountAll()
        {
            return _context.Set<T>().CountAsync();
        }

        public void InsertMultiple(IEnumerable<T> entities)
        {
            _context.AddRange(entities);
        }
        #endregion
    }
}
