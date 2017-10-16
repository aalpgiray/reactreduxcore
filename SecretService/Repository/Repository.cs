using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SecretService.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        private DbSet<TEntity> _dbSet;

        public Repository(DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }

        public virtual void Add(TEntity item)
        {
            _dbSet.Add(item);
        }

        public virtual void AddRange(IEnumerable<TEntity> items)
        {
            _dbSet.AddRange(items);
        }

        public virtual void Delete(TEntity item)
        {
            _dbSet.Remove(item);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> items)
        {
            _dbSet.RemoveRange(items);
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return _dbSet;
        }

        public virtual TEntity Get(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
