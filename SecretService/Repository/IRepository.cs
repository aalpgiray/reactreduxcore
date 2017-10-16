using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SecretService.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Query(Expression<Func<TEntity,bool>> expression);
        IEnumerable<TEntity> Get();
        TEntity Get(object id);
        void Add(TEntity item);
        void AddRange(IEnumerable<TEntity> item);
        void Delete(TEntity item);
        void DeleteRange(IEnumerable<TEntity> item);
    }
}
