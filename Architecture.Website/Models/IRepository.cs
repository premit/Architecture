using System;
using System.Linq;
using System.Linq.Expressions;

namespace Architecture.Website.Models
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        TEntity Create(TEntity entity);
        TEntity Find(int id);
        IQueryable<TEntity> FindAll();
        TEntity Update(TEntity entity);
        bool Update(TEntity entity, params Expression<Func<TEntity, object>>[] properties);
        bool Delete(int id);
        int Save();
    }
}
